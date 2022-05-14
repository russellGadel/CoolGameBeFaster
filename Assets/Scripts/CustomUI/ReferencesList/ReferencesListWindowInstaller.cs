using UnityEngine;
using Zenject;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindViewModel();
        }

        [SerializeField] private ReferencesListWindowView _view;

        private void BindViewModel()
        {
            Container
                .Bind<IReferencesListWindowViewModel>()
                .To<ReferencesListWindowViewModel>()
                .FromInstance(new ReferencesListWindowViewModel(InstallModel(), _view))
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