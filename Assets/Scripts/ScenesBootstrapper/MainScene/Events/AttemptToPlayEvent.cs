using System.Collections;
using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class AttemptToPlayEvent : ICustomEventLoader
    {
        private readonly IAttemptToPlayView _attemptToPlayView;

        [Inject]
        public AttemptToPlayEvent(IAttemptToPlayView attemptToPlayView)
        {
            _attemptToPlayView = attemptToPlayView;
        }

        public void Execute()
        {
            _attemptToPlayView.Open();
        }

        public IEnumerator Load()
        {
            Debug.Log("Load attempt to Play");
            AddObserverToContinueGameEvent();
            AddObserverToRepeatGameButton();

            yield return null;
        }

        private void AddObserverToContinueGameEvent()
        {
            _attemptToPlayView.AddObserverToAdvertisingButton(AdvertisingButtonObservers);
            _attemptToPlayView.AddObserverToAdvertisingButton(_attemptToPlayView.Close);
        }

        private void AdvertisingButtonObservers()
        {
            Debug.Log("AdvertisingButtonObservers");
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new ContinueGameAfterGameOverEvent());
        }

        private void AddObserverToRepeatGameButton()
        {
            _attemptToPlayView.AddObserverToRepeatButton(RepeatGameButtonObservers);
            _attemptToPlayView.AddObserverToAdvertisingButton(_attemptToPlayView.Close);
        }

        private void RepeatGameButtonObservers()
        {
            Debug.Log("RepeatGameButtonObservers");

            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new ContinueGameAfterGameOverEvent());
        }
    }
}