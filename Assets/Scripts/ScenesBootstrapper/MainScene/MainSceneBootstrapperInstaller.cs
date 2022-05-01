using ScenesBootstrapper.MainScene.Ecs;
using ScenesBootstrapper.MainScene.Events;
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
            BindEvents();
        }


        private void BindMainSceneBootstrapper()
        {
            Container
                .Bind<ISceneBootstrapper>()
                .To<MainSceneBootstrapper>()
                .AsSingle();
        }


        [SerializeField] private MainSceneEcsBootstrapper mainSceneEcsBootstrapper;

        private void BindEscBootstrapper()
        {
            Container
                .Bind<MainSceneEcsBootstrapper>()
                .FromInstance(mainSceneEcsBootstrapper)
                .AsSingle();
        }

        private void BindUIInstaller()
        {
            Container
                .Bind<MainSceneInstallersBootstrapper>()
                .AsSingle();
        }

        private void BindEvents()
        {
            Container
                .Bind<MainSceneEventsBootstrapper>()
                .AsSingle();
        }
    }
}