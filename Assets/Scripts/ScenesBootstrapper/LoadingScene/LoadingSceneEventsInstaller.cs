using CustomEvents;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoadingWindowEvents();
            BindSaveDataEvent();
            BindLoadSavedDataEvent();
            BindPrivacyPolicyWindowEvent();
            BindRemoteConfigDataEvent();
            BindUpdateGameWindowEvents();
            BindSetGameTypeEvent();
        }
        
        private void BindLoadingWindowEvents()
        {
            Container
                .Bind<LoadingWindowDualEvents>()
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
                .Bind<PrivacyPolicyWindowEvents>()
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

        private void BindSetGameTypeEvent()
        {
            Container
                .Bind<SetGameTypeEvent>()
                .AsSingle();
        }
    }
}