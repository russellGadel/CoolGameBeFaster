using System;
using System.Collections;
using Core.EventsLoader;
using CustomUI.PrivacyPolicy;
using Services.SaveData;
using UnityEngine;
using Zenject;

namespace CustomEvents
{
    public sealed class PrivacyPolicyWindowEvents : ICustomDualEvent
        , ICustomEventLoader
        , IDisposable
    {
        private readonly IPrivacyPolicyPresenter _privacyPolicyPresenter;
        private readonly LoadingWindowDualEvents _loadingWindowDualEvents;
        private readonly ISaveDataService _saveDataService;

        [Inject]
        public PrivacyPolicyWindowEvents(IPrivacyPolicyPresenter privacyPolicyPresenter
            , LoadingWindowDualEvents loadingWindowDualEvents
            , ISaveDataService saveDataService)
        {
            _privacyPolicyPresenter = privacyPolicyPresenter;
            _loadingWindowDualEvents = loadingWindowDualEvents;
            _saveDataService = saveDataService;
        }

        public IEnumerator Load()
        {
            if (UserHasAgreedPrivacyPolicy() == false)
            {
                SubscribeToAcceptButton();
                SubscribeToDeclineButton();

                _loadingWindowDualEvents.Undo();
                Execute();

                yield return new WaitWhile(() => _privacyPolicyPresenter.IsAcceptAgreement() == false);

                _loadingWindowDualEvents.Execute();
            }

            yield return null;
        }

        public void Execute()
        {
            _privacyPolicyPresenter.Open();
        }

        public void Undo()
        {
            _privacyPolicyPresenter.Close();
        }


        void IDisposable.Dispose()
        {
            UnsubscribeFromAcceptButton();
            UnsubscribeToDeclineButton();
        }

        private bool UserHasAgreedPrivacyPolicy()
        {
            return _saveDataService.GetData().isAgreedPrivacyPolicy;
        }


        private void SubscribeToAcceptButton()
        {
            _privacyPolicyPresenter
                .SubscribeToAcceptButton(AcceptButtonObservers);
        }

        private void UnsubscribeFromAcceptButton()
        {
            _privacyPolicyPresenter
                .UnsubscribeFromAcceptButton(AcceptButtonObservers);
        }

        private void AcceptButtonObservers()
        {
            _privacyPolicyPresenter.Close();
            _saveDataService.GetData().isAgreedPrivacyPolicy = true;

            _privacyPolicyPresenter.UserAcceptPrivacyPolicy();
        }


        private void SubscribeToDeclineButton()
        {
            _privacyPolicyPresenter.SubscribeToDeclineButton(DeclineButtonObservers);
        }

        private void UnsubscribeToDeclineButton()
        {
            _privacyPolicyPresenter.UnsubscribeFromDeclineButton(DeclineButtonObservers);
        }

        private void DeclineButtonObservers()
        {
            Application.Quit();
        }
    }
}