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
                AddObserversToAcceptButton();
                AddObserversToDeclineButton();

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


        private bool UserHasAgreedPrivacyPolicy()
        {
            return _saveDataService.GetData().isAgreedPrivacyPolicy;
        }


        private void AddObserversToAcceptButton()
        {
            _privacyPolicyPresenter
                .AddObserverToAcceptButton(AcceptButtonObservers);
        }

        private void AcceptButtonObservers()
        {
            _privacyPolicyPresenter.Close();
            _saveDataService.GetData().isAgreedPrivacyPolicy = true;

            _privacyPolicyPresenter.UserAcceptPrivacyPolicy();
        }


        private void AddObserversToDeclineButton()
        {
            _privacyPolicyPresenter.AddObserverToDeclineButton(DeclineButtonObservers);
        }

        private void DeclineButtonObservers()
        {
            Application.Quit();
        }
    }
}