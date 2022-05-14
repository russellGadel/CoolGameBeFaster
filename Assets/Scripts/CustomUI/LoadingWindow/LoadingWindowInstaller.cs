using UnityEngine;
using Zenject;

namespace CustomUI.LoadingWindow
{
    public sealed class LoadingWindowInstaller : MonoInstaller
    {
        [SerializeField] private LoadingWindowView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<ILoadingWindowView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}