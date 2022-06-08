using CustomEvents;
using CustomEvents.GameTime;
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
            BindPlayerAccelerationButton();
            BindLoadingWindowEvents();

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
            Container.Bind<PauseButtonEvents>().AsSingle();
        }

        private void BindAttemptToPlayEvent()
        {
            Container.Bind<AttemptToPlayWindowEvents>().AsSingle();
        }

        private void BindGameOver()
        {
            Container.Bind<GameOverWindowEvents>().AsSingle();
        }

        private void BindPlayerAccelerationButton()
        {
            Container.Bind<PlayerAccelerationButtonEvents>().AsSingle();
        }

        private void BindLoadingWindowEvents()
        {
            Container.Bind<LoadingWindowDualEvents>().AsSingle();
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
            Container.Bind<StartWindowEvents>().AsSingle();
        }
    }
}