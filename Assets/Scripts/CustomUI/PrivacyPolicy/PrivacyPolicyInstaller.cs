using UnityEngine;
using Zenject;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPresenter();
        }

        [SerializeField] private PrivacyPolicyView _view;

        private void BindPresenter()
        {
            Container
                .Bind<IPrivacyPolicyPresenter>()
                .To<PrivacyPolicyPresenter>()
                .FromMethod(() => InstallPresenter(_view, InstallModel(_settings)))
                .AsSingle();
        }


        private PrivacyPolicyPresenter InstallPresenter(IPrivacyPolicyView view
            , IPrivacyPolicyModel model)
        {
            return new PrivacyPolicyPresenter(view, model);
        }

    
        [SerializeField] private PrivacyPolicySettings _settings;

        private IPrivacyPolicyModel InstallModel(PrivacyPolicySettings settings)
        {
            return new PrivacyPolicyModel(settings);
        }
    }
}