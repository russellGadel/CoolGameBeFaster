using System;
using System.Collections;
using Core.EventsLoader;
using CustomUI.GameOverView;
using ECS.Events;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace CustomEvents
{
    public sealed class GameOverWindowEvents : ICustomEventLoader
        , IDisposable
    {
        private readonly IGameOverView _gameOverView;

        [Inject]
        public GameOverWindowEvents(IGameOverView gameOverView)
        {
            _gameOverView = gameOverView;
        }


        public IEnumerator Load()
        {
            SubscribeToRepeatButton();
            yield return null;
        }

        public void Execute(in double currentPoints, in double maxPoints)
        {
            _gameOverView.SetCurrentPointsAmount(currentPoints);
            _gameOverView.SetMaxPointsAmount(maxPoints);

            _gameOverView.Open();
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromRepeatButton();
        }

        private void SubscribeToRepeatButton()
        {
            _gameOverView.SubscribeToRepeatButton(RepeatButtonObservers);
        }

        private void UnsubscribeFromRepeatButton()
        {
            _gameOverView.UnsubscribeFromRepeatButton(RepeatButtonObservers);
        }

        private void RepeatButtonObservers()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new StartGameEcsEvent());

            _gameOverView.Close();
        }
    }
}