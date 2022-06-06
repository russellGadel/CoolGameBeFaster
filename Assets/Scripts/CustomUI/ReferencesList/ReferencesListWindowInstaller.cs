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

        [SerializeField] private ReferencesListWindowView _view;

        private void BindPresenter()
        {
            Container
                .Bind<IReferencesListWindowPresenter>()
                .To<ReferencesListWindowPresenter>()
                .FromInstance(new ReferencesListWindowPresenter(InstallModel(), _view))
                .AsSingle();
        }


        [SerializeField] private ReferencesListSettings settings;

        private IReferencesListWindowModel InstallModel()
        {
            ReferencesListWindowModel model = new ReferencesListWindowModel(settings);
            return model;
        }
    }
}