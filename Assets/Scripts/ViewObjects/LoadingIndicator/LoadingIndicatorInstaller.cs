using UnityEngine;
using Zenject;

namespace ViewObjects.LoadingIndicator
{
    public sealed class LoadingIndicatorInstaller : MonoInstaller
    {
        [SerializeField] private LoadingIndicatorView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<ILoadingIndicatorView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}