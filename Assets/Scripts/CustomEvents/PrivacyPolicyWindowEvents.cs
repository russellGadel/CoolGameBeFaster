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
        private readonly IPrivacyPolicyViewModel _privacyPolicyViewModel;
        private readonly LoadingWindowDualEvents _loadingWindowDualEvents;
        private readonly ISaveDataService _saveDataService;

        [Inject]
        public PrivacyPolicyWindowEvents(IPrivacyPolicyViewModel privacyPolicyViewModel
            , LoadingWindowDualEvents loadingWindowDualEvents
            , ISaveDataService saveDataService)
        {
            _privacyPolicyViewModel = privacyPolicyViewModel;
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

                yield return new WaitWhile(() => _privacyPolicyViewModel.IsAcceptAgreement() == false);

                _loadingWindowDualEvents.Execute();
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