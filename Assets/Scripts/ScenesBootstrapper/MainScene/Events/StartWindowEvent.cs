using System.Collections;
using Core.EventsLoader;
using CustomUI.PlayerAccelerationButton;
using CustomUI.PlayerController;
using CustomUI.StartWindow;
using CustomUI.UpperGamePlayPanel;
using ECS.Events;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class StartWindowEvent : ICustomEventLoader
    {
        private readonly IStartWindowView _startWindowView;
        private readonly IUpperGamePlayPanelView _upperGamePlayPanelView;
        private readonly IPlayerControllerPresenter _playerControllerPresenter;
        private readonly IPlayerAccelerationButtonView _playerAccelerationButtonView;


        [Inject]
        private StartWindowEvent(IUpperGamePlayPanelView upperGamePlayPanelView,
            IPlayerControllerPresenter playerControllerPresenter, IStartWindowView startWindowView,
            IPlayerAccelerationButtonView playerAccelerationButtonView)
        {
            _startWindowView = startWindowView;
            _upperGamePlayPanelView = upperGamePlayPanelView;
            _playerControllerPresenter = playerControllerPresenter;
            _playerAccelerationButtonView = playerAccelerationButtonView;
        }

        public IEnumerator Load()
        {
            AddObserversToStartButton();
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
    }
}