using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.MainScene
{
    public sealed class MainSceneBootstrapperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMainSceneBootstrapper();
            BindEscBootstrapper();
            BindUIInstaller();
        }


        private void BindMainSceneBootstrapper()
        {
            Container
                .Bind<ISceneBootstrapper>()
                .To<MainSceneBootstrapper>()
                .AsSingle();
        }


        [SerializeField] private EscBootstrapperMainScene _escBootstrapper;

        private void BindEscBootstrapper()
        {
            Container
                .Bind<EscBootstrapperMainScene>()
                .FromInstance(_escBootstrapper)
                .AsSingle();
        }

        private void BindUIInstaller()
        {
            Container
                .Bind<UIBootstrapperMainScene>()
                .AsSingle();
        }
    }
}