using Zenject;

namespace ScenesLoader
{
    public sealed class CustomScenesLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICustomScenesLoader>()
                .To<CustomScenesLoader>()
                .AsSingle();
        }
    }
}