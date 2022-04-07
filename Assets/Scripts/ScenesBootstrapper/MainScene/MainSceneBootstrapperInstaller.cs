using ScenesBootstrapper.MainScene.Ecs;
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


        [SerializeField] private EcsBootstrapperMainScene ecsBootstrapper;

        private void BindEscBootstrapper()
        {
            Container
                .Bind<EcsBootstrapperMainScene>()
                .FromInstance(ecsBootstrapper)
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