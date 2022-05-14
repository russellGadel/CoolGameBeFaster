using Services.InternetConnection;
using UnityEngine;
using Zenject;

namespace Services.UnityAds
{
    public sealed class UnityAdsServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUnityAdsService>()
                .FromInstance(InstallService())
                .AsSingle();
        }

        [SerializeField] private UnityAdsService _service;
        [SerializeField] private UnityAdsSettings _settings;
        [Inject] private IInternetConnectionService _internetConnectionService;

        private UnityAdsService InstallService()
        {
            _settings.Load();
            _service.Construct(_settings, _internetConnectionService);
            return _service;
        }
    }
}