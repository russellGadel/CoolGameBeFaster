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
            BindRemoteConfigDataEvent();
            BindUpdateGameWindowEvents();
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

        private void BindRemoteConfigDataEvent()
        {
            Container
                .Bind<RemoteConfigDataEvents>()
                .AsSingle();
        }

        private void BindUpdateGameWindowEvents()
        {
            Container
                .Bind<UpdateGameWindowEvents>()
                .AsSingle();
        }
    }
}