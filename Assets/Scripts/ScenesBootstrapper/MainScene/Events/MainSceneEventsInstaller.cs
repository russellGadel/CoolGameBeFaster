﻿using ScenesBootstrapper.MainScene.Events.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPauseEvent();
            BindUnpauseEvent();
            BindPauseButtonEvent();
            BindSaveDataEvent();
            BindAttemptToPlayEvent();
            BindGameOver();

            BindLoadSavedDataEvent();

            BindMainSceneEventsService();
            BindStartGameEvent();
            BindStartWindowEvent();
        }


        private void BindPauseEvent()
        {
            Container.Bind<PlayerPauseEvent>().AsSingle();
        }

        private void BindUnpauseEvent()
        {
            Container.Bind<PlayerUnpauseEvent>().AsSingle();
        }

        private void BindPauseButtonEvent()
        {
            Container.Bind<PauseButtonEvent>().AsSingle();
        }

        private void BindAttemptToPlayEvent()
        {
            Container.Bind<AttemptToPlayEvent>().AsSingle();
        }

        private void BindGameOver()
        {
            Container.Bind<GameOverEvent>().AsSingle();
        }

        private void BindSaveDataEvent()
        {
            Container.Bind<SaveDataEvent>().AsSingle();
        }

        private void BindLoadSavedDataEvent()
        {
            Container.Bind<LoadSavedDataEvent>().AsSingle();
        }

        private void BindMainSceneEventsService()
        {
            Container.Bind<MainSceneEventsService>().AsSingle();
        }

        private void BindStartGameEvent()
        {
            Container.Bind<StartGameEvent>().AsSingle();
        }

        private void BindStartWindowEvent()
        {
            Container.Bind<StartWindowEvent>().AsSingle();
        }
    }
}