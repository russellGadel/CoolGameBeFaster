using CustomUI.InternetConnection;
using UnityEngine;
using Zenject;

namespace Services.InternetConnection
{
    public sealed class InternetConnectionInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindService();
        }

        private void BindService()
        {
            Container
                .Bind<IInternetConnectionService>()
                .FromMethod(InstallService)
                .AsSingle();
        }

        [SerializeField] private InternetConnectionPresenter _presenter;

        [SerializeField] private HasNotInternetConnectionView _hasNotConnectionView;

        private IInternetConnectionService InstallService()
        {
            InternetConnectionModel model = InstallModel();

            _presenter.Construct(model, _hasNotConnectionView);
            return _presenter;
        }


        [SerializeField] private InternetConnectionSettings _settings;

        private InternetConnectionModel InstallModel()
        {
            return new InternetConnectionModel(_settings);
        }
    }
}