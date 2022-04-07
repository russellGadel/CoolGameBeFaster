using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneBootstrapperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindBootstrapper();
        }

        private void BindBootstrapper()
        {
            Container
                .Bind<ISceneBootstrapper>()
                .To<LoadingSceneBootstrapper>()
                .AsSingle();
        }
    }
}