using Zenject;

namespace Services.RemoteConfigData
{
    public sealed class RemoteConfigDataInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallRemoteConfigData();
            BindRemoteConfigData();
            BindRemoteConfigDataForLoader();
            BindSettings();
        }

        private readonly RemoteConfigSettings _settings = new RemoteConfigSettings();

        private RemoteConfigData _remoteConfigData;

        private void InstallRemoteConfigData()
        {
            _remoteConfigData = new RemoteConfigData(in _settings);
        }


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


        private void BindSettings()
        {
            Container
                .Bind<RemoteConfigSettings>()
                .FromInstance(_settings)
                .AsSingle();
        }
    }
}