using System.Collections;
using Core.EventsLoader;
using CustomUI.GameOverView;
using ECS.Events;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class GameOverEvent : ICustomEventLoader
    {
        private readonly IGameOverView _gameOverView;

        [Inject]
        public GameOverEvent(IGameOverView gameOverView)
        {
            _gameOverView = gameOverView;
        }


        public IEnumerator Load()
        {
            AddObserversToRepeatButton();
            yield return null;
        }

        public void Execute(double currentPoints, double maxPoints)
        {
            _gameOverView.SetCurrentPointsAmount(currentPoints);
            _gameOverView.SetMaxPointsAmount(maxPoints);
            
            _gameOverView.Open();
        }

        private void AddObserversToRepeatButton()
        {
            _gameOverView.AddObserverToRepeatButton(RepeatButtonObservers);
        }

        private void RepeatButtonObservers()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new StartGameEcsEvent());

            _gameOverView.Close();
        }
    }
}