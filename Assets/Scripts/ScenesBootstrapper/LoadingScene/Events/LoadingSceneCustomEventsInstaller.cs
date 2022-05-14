using Zenject;

namespace ScenesBootstrapper.LoadingScene.Events
{
    public sealed class LoadingSceneCustomEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindLoadingWindowEvents();
        }

        private void BindLoadingWindowEvents()
        {
            Container
                .Bind<LoadingWindowEvents>()
                .AsSingle();
        }
    }
}