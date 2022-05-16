using UnityEngine;
using Zenject;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindViewModel();
        }

        [SerializeField] private PrivacyPolicyView _view;

        private void BindViewModel()
        {
            Container
                .Bind<IPrivacyPolicyViewModel>()
                .To<PrivacyPolicyViewModel>()
                .FromMethod(() => InstallViewModel(_view, InstallModel(_settings)))
                .AsSingle();
        }


        private PrivacyPolicyViewModel InstallViewModel(IPrivacyPolicyView view
            , IPrivacyPolicyModel model)
        {
            return new PrivacyPolicyViewModel(view, model);
        }

    
        [SerializeField] private PrivacyPolicySettings _settings;

        private IPrivacyPolicyModel InstallModel(PrivacyPolicySettings settings)
        {
            return new PrivacyPolicyModel(settings);
        }
    }
}