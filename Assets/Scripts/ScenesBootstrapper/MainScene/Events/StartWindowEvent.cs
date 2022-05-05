using System.Collections;
using Core.EventsLoader;
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


        [Inject]
        private StartWindowEvent(IUpperGamePlayPanelView upperGamePlayPanelView,
            IPlayerControllerPresenter playerControllerPresenter, IStartWindowView startWindowView)
        {
            _startWindowView = startWindowView;
            _upperGamePlayPanelView = upperGamePlayPanelView;
            _playerControllerPresenter = playerControllerPresenter;
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
            _startWindowView.AddObserversToPressStartGameButton(ObserversStartWindowView);
        }

        private void ObserversStartWindowView()
        {
            _upperGamePlayPanelView.Open();
            _playerControllerPresenter.OpenView();

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