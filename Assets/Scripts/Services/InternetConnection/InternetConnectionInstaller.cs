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

        [SerializeField] private InternetConnectionViewModel _viewModel;

        [SerializeField] private HasNotInternetConnectionView _hasNotConnectionView;

        private IInternetConnectionService InstallService()
        {
            InternetConnectionModel model = InstallModel();

            _viewModel.Construct(model, _hasNotConnectionView);
            return _viewModel;
        }


        [SerializeField] private InternetConnectionSettings _settings;

        private InternetConnectionModel InstallModel()
        {
            return new InternetConnectionModel(_settings);
        }
    }
}