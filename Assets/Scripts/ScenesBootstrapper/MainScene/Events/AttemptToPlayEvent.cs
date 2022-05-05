using System.Collections;
using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using ECS.Events;
using Leopotam.Ecs;
using Services.GameTime;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class AttemptToPlayEvent : ICustomEventLoader
    {
        private readonly IAttemptToPlayView _attemptToPlayView;
        private readonly IGameTimeService _gameTimeService;

        [Inject]
        public AttemptToPlayEvent(IAttemptToPlayView attemptToPlayView
            , IGameTimeService gameTimeService)
        {
            _attemptToPlayView = attemptToPlayView;
            _gameTimeService = gameTimeService;
        }

        public void Execute(double currentPoints, double maxPoints)
        {
            _attemptToPlayView.SetCurrentPointsAmount(currentPoints);
            _attemptToPlayView.SetMaxPointsAmount(maxPoints);

            _attemptToPlayView.Open();
        }

        public IEnumerator Load()
        {
            AddObserverToContinueGameEvent();
            AddObserverToRepeatGameButton();

            yield return null;
        }

        private void AddObserverToContinueGameEvent()
        {
            _attemptToPlayView.AddObserverToAdvertisingButton(AdvertisingButtonObservers);
        }

        private void AdvertisingButtonObservers()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new ContinueGameAfterGameOverEvent());

            _attemptToPlayView.Close();
        }

        private void AddObserverToRepeatGameButton()
        {
            _attemptToPlayView.AddObserverToRepeatButton(RepeatGameButtonObservers);
        }

        private void RepeatGameButtonObservers()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new StartGameEcsEvent());

            _attemptToPlayView.Close();
        }
    }
}