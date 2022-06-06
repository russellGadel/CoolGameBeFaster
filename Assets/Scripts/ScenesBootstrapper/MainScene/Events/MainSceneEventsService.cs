﻿using CustomEvents;
using CustomEvents.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsService
    {
        [Inject] public PlayerPauseEvent PlayerPauseEvent;
        [Inject] public PlayerUnpauseEvent PlayerUnpauseEvent;
        [Inject] public AttemptToPlayEvent AttemptToPlayEvent;
        [Inject] public GameOverEvent GameOverEvent;
        [Inject] public SaveDataEvent SaveDataEvent;
    }
}