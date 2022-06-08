using System;
using System.Collections;
using Core.EventsLoader;
using CustomUI.UpdateGame;
using Services.ApplicationService;
using Services.RemoteConfigData;
using UnityEngine;
using Zenject;

namespace CustomEvents
{
    public sealed class UpdateGameWindowEvents : ICustomEventLoader
        , IDisposable
    {
        private readonly IUpdateGamePresenter _updateGamePresenter;
        private readonly IApplicationService _applicationService;
        private readonly IRemoteConfigData _remoteConfigData;

        [Inject]
        public UpdateGameWindowEvents(IUpdateGamePresenter updateGamePresenter
            , IApplicationService applicationService
            , IRemoteConfigData remoteConfigData)
        {
            _updateGamePresenter = updateGamePresenter;
            _applicationService = applicationService;
            _remoteConfigData = remoteConfigData;
        }

        public IEnumerator Load()
        {
            if (Application.version != _remoteConfigData.GameVersion)
            {
                SubscribeToUpdateButton();
                _updateGamePresenter.OpenView();

                bool exitFromGame = true;
                yield return new WaitUntil(() => exitFromGame == true);
            }

            yield return null;
        }

        public void Dispose()
        {
            UnsubscribeFromUpdateButton();
        }


        private void SubscribeToUpdateButton()
        {
            _updateGamePresenter.SubscribeToUpdateButton(UpdateButtonObservers);
        }

        private void UnsubscribeFromUpdateButton()
        {
            _updateGamePresenter.UnsubscribeFromPressUpdateButton(UpdateButtonObservers);
        }

        private void UpdateButtonObservers()
        {
            _updateGamePresenter.GoToAppStore();
            _applicationService.Quit();
        }
    }
}