using ScenesBootstrapper.MainScene.Events;
using Zenject;

namespace ScenesBootstrapper.LoadingScene.Events
{
    public sealed class LoadingSceneCustomEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoadingWindowEvents();
            BindSaveDataEvent();
            BindLoadSavedDataEvent();
            BindPrivacyPolicyWindowEvent();
        }

        private void BindLoadingWindowEvents()
        {
            Container
                .Bind<LoadingWindowEvents>()
                .AsSingle();
        }


        private void BindSaveDataEvent()
        {
            Container
                .Bind<SaveDataEvent>()
                .AsSingle();
        }

        private void BindLoadSavedDataEvent()
        {
            Container
                .Bind<LoadSavedDataEvent>()
                .AsSingle();
        }

        private void BindPrivacyPolicyWindowEvent()
        {
            Container
                .Bind<PrivacyPolicyWindowEvent>()
                .AsSingle();
        }
    }
}