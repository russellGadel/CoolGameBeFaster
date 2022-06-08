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
        [SerializeField] private PrivacyPolicySettings _settings;

        private void BindPresenter()
        {
            Container
                .Bind<IPrivacyPolicyPresenter>()
                .To<PrivacyPolicyPresenter>()
                .FromMethod(() => InstallPresenter(_view, InstallModel(in _settings)))
                .AsSingle();
        }


        private PrivacyPolicyPresenter InstallPresenter(in IPrivacyPolicyView view
            , in IPrivacyPolicyModel model)
        {
            return new PrivacyPolicyPresenter(in view, in model);
        }


        private IPrivacyPolicyModel InstallModel(in PrivacyPolicySettings settings)
        {
            return new PrivacyPolicyModel(in settings);
        }
    }
}