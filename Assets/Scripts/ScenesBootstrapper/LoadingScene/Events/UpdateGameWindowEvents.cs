using System.Collections;
using Core.EventsLoader;
using CustomUI.UpdateGame;
using Services.ApplicationService;
using Services.RemoteConfigData;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.LoadingScene.Events
{
    public sealed class UpdateGameWindowEvents : ICustomEventLoader
    {
        private readonly IUpdateGameViewModel _updateGameViewModel;
        private readonly IApplicationService _applicationService;
        private readonly IRemoteConfigData _remoteConfigData;

        [Inject]
        public UpdateGameWindowEvents(IUpdateGameViewModel updateGameViewModel
            , IApplicationService applicationService)
        {
            _updateGameViewModel = updateGameViewModel;
            _applicationService = applicationService;
        }

        public IEnumerator Load()
        {
            if (UnityEngine.Application.version != _remoteConfigData.GameVersion)
            {
                AddObserversToUpdateButton();
                _updateGameViewModel.OpenView();

                bool exitFromGame = true;
                yield return new WaitUntil(() => exitFromGame == true);
            }

            yield return null;
        }

        private void AddObserversToUpdateButton()
        {
            _updateGameViewModel.AddObserverToUpdateButton(UpdateButtonObservers);
        }

        private void UpdateButtonObservers()
        {
            _updateGameViewModel.GoToAppStore();
            _applicationService.Quit();
        }
    }
}