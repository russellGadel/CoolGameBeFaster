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
    public sealed class StartWindowEvents : ICustomEventLoader
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
            AddObserversToStartButton();
            AddObserversToPressOnReferencesListButtonEvent();
            SetMaxPointsAtStartView();

            yield return null;
        }

        public void Execute()
        {
            _startWindowView.Open();
        }


        private void AddObserversToStartButton()
        {
            _startWindowView.AddObserversToPressStartGameButton(ObserversPressStartButtonEvent);
        }

        private void ObserversPressStartButtonEvent()
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

        private void AddObserversToPressOnReferencesListButtonEvent()
        {
            _startWindowView
                .AddObserversToFirstPressOnReferencesListButton(_referencesListWindowPresenter.Open);

            _startWindowView
                .AddObserversToSecondPressOnReferencesListButton(_referencesListWindowPresenter.Close);
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
                .ToString(CultureInfo.CurrentCulture);
        }
    }
}