﻿using System.Collections;
using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using ECS.Events;
using Leopotam.Ecs;
using Services.GameTime;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class AttemptToPlayEvent : ICustomEventLoader
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
        }

        private void AdvertisingButtonObservers()
        {
            Debug.Log("AdvertisingButtonObservers");
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
            Debug.Log("RepeatGameButtonObservers");
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new StartGameEvent());
            
            _attemptToPlayView.Close();
        }
    }
}