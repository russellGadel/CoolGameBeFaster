using UnityEngine;
using Zenject;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPresenter();
        }


        private void BindPresenter()
        {
            Container
                .Bind<IReferencesListWindowPresenter>()
                .To<ReferencesListWindowPresenter>()
                .FromInstance(new ReferencesListWindowPresenter(InstallModel(), InstallView()))
                .AsSingle();
        }


        [SerializeField] private ReferencesListSettings _settings;

        private IReferencesListWindowModel InstallModel()
        {
            return new ReferencesListWindowModel(_settings);
        }

        [SerializeField] private ReferencesListWindowView _view;

        private ReferencesListWindowView InstallView()
        {
            _view.Construct(_settings);
            return _view;
        }
    }
}