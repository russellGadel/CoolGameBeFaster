using Core.EventsLoader;
using CustomUI.GameOverView;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class GameOverEvent : ICustomEvent
    {
        private readonly IGameOverView _gameOverView;

        [Inject]
        public GameOverEvent(IGameOverView gameOverView)
        {
            _gameOverView = gameOverView;
        }

        public void Execute()
        {
            _gameOverView.Open();
        }
    }
}