using Zenject;

namespace Services.RemoteConfigData
{
    public sealed class RemoteConfigDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindRemoteConfigData();
            BindRemoteConfigDataForLoader();
        }


        private readonly RemoteConfigData _remoteConfigData = new RemoteConfigData();

        private void BindRemoteConfigData()
        {
            Container
                .Bind<IRemoteConfigData>()
                .FromInstance(_remoteConfigData)
                .AsSingle();
        }

        private void BindRemoteConfigDataForLoader()
        {
            Container
                .Bind<IRemoteConfigDataForLoader>()
                .FromInstance(_remoteConfigData)
                .AsSingle();
        }
    }
}