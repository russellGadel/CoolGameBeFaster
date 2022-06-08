using System;
using System.Collections;
using System.Globalization;
using Core.EventsLoader;
using CustomUI.PlayerAccelerationButton;
using CustomUI.PlayerController;
using CustomUI.ReferencesList;
using CustomUI.StartWindow;
using CustomUI.UpperGamePlayPanel;
using ECS.Events;
using Leopotam.Ecs;
using Services.SaveData;
using Voody.UniLeo;
using Zenject;

namespace CustomEvents
{
    public sealed class StartWindowEvents : ICustomEventLoader,
        IDisposable
    {
        private readonly IStartWindowView _startWindowView;
        private readonly IUpperGamePlayPanelView _upperGamePlayPanelView;
        private readonly IPlayerControllerPresenter _playerControllerPresenter;
        private readonly IPlayerAccelerationButtonView _playerAccelerationButtonView;
        private readonly ISaveDataService _saveDataService;
        private readonly IReferencesListWindowPresenter _referencesListWindowPresenter;


        [Inject]
        private StartWindowEvents(IUpperGamePlayPanelView upperGamePlayPanelView
            , IPlayerControllerPresenter playerControllerPresenter
            , IStartWindowView startWindowView
            , IPlayerAccelerationButtonView playerAccelerationButtonView
            , ISaveDataService saveDataService
            , IReferencesListWindowPresenter referencesListWindowPresenter)
        {
            _startWindowView = startWindowView;
            _upperGamePlayPanelView = upperGamePlayPanelView;
            _playerControllerPresenter = playerControllerPresenter;
            _playerAccelerationButtonView = playerAccelerationButtonView;
            _saveDataService = saveDataService;
            _referencesListWindowPresenter = referencesListWindowPresenter;
        }

        public IEnumerator Load()
        {
            SubscribeToStartButton();
            SubscribeToPressOnReferencesListButton();

            SetMaxPointsAtStartView();

            yield return null;
        }

        public void Execute()
        {
            _startWindowView.Open();
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromStartButton();
            UnsubscribeFromPressOnReferencesListButton();
        }


        private void SubscribeToStartButton()
        {
            _startWindowView.SubscribeToPressStartGameButton(ObserversPressStartButton);
        }

        private void UnsubscribeFromStartButton()
        {
            _startWindowView.UnsubscribeFromPressStartGameButton(ObserversPressStartButton);
        }


        private void ObserversPressStartButton()
        {
            _upperGamePlayPanelView.Open();
            _playerControllerPresenter.OpenView();
            _playerAccelerationButtonView.Open();

            StartEcsGame();

            _startWindowView.Close();
        }

        private static void StartEcsGame()
        {
            EcsEntity startGameEntity = WorldHandler.GetWorld().NewEntity();
            startGameEntity.Replace(new StartGameEcsEvent());
        }

        private void SubscribeToPressOnReferencesListButton()
        {
            _startWindowView
                .SubscribeToFirstPressOnReferencesListButton(_referencesListWindowPresenter.Open);

            _startWindowView
                .SubscribeToSecondPressOnReferencesListButton(_referencesListWindowPresenter.Close);
        }

        private void UnsubscribeFromPressOnReferencesListButton()
        {
            _startWindowView
                .UnsubscribeFromFirstPressOnReferencesListButton(_referencesListWindowPresenter.Open);

            _startWindowView
                .UnsubscribeFromSecondPressOnReferencesListButton(_referencesListWindowPresenter.Close);
        }

        private void SetMaxPointsAtStartView()
        {
            _startWindowView.SetMaxPoints(GetSavedMaxPoints());
        }

        private string GetSavedMaxPoints()
        {
            return _saveDataService
                .GetData()
                .maxPointsAmountGotByPlayer
                .ToString(CultureInfo.InvariantCulture);
        }
    }
}