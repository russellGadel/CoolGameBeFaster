using System.Collections;
using Core.EventsLoader;
using CustomUI.PrivacyPolicy;
using Services.SaveData;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.LoadingScene.Events
{
    public sealed class PrivacyPolicyWindowEvent : ICustomDualEvent
        , ICustomEventLoader
    {
        private readonly IPrivacyPolicyViewModel _privacyPolicyViewModel;
        private readonly LoadingWindowEvents _loadingWindowEvents;
        private readonly ISaveDataService _saveDataService;

        [Inject]
        public PrivacyPolicyWindowEvent(IPrivacyPolicyViewModel privacyPolicyViewModel
            , LoadingWindowEvents loadingWindowEvents
            , ISaveDataService saveDataService)
        {
            _privacyPolicyViewModel = privacyPolicyViewModel;
            _loadingWindowEvents = loadingWindowEvents;
            _saveDataService = saveDataService;
        }

        public IEnumerator Load()
        {
            if (UserHasAgreedPrivacyPolicy() == false)
            {
                AddObserversToAcceptButton();
                AddObserversToDeclineButton();

                _loadingWindowEvents.Undo();
                Execute();

                yield return new WaitWhile(() => _privacyPolicyViewModel.IsAcceptAgreement() == false);

                _loadingWindowEvents.Execute();
            }

            yield return null;
        }

        public void Execute()
        {
            _privacyPolicyViewModel.Open();
        }

        public void Undo()
        {
            _privacyPolicyViewModel.Close();
        }


        private bool UserHasAgreedPrivacyPolicy()
        {
            return _saveDataService.GetData().isAgreedPrivacyPolicy;
        }


        private void AddObserversToAcceptButton()
        {
            _privacyPolicyViewModel
                .AddObserverToAcceptButton(AcceptButtonObservers);
        }

        private void AcceptButtonObservers()
        {
            _privacyPolicyViewModel.Close();
            _saveDataService.GetData().isAgreedPrivacyPolicy = true;

            _privacyPolicyViewModel.UserAcceptPrivacyPolicy();
        }


        private void AddObserversToDeclineButton()
        {
            _privacyPolicyViewModel.AddObserverToDeclineButton(DeclineButtonObservers);
        }

        private void DeclineButtonObservers()
        {
            Application.Quit();
        }
    }
}