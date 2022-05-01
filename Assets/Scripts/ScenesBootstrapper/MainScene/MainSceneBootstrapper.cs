using Core.BootstrapExecutor;
using ScenesBootstrapper.MainScene.Ecs;
using ScenesBootstrapper.MainScene.Events;
using Zenject;

namespace ScenesBootstrapper.MainScene
{
    public sealed class MainSceneBootstrapper : ISceneBootstrapper
    {
        public void Enter()
        {
            AddBootstrapItems();
            _bootstrapsExecutor.Execute();
        }

        public void Exit()
        {
        }

        [Inject] private IBootstrapExecutor _bootstrapsExecutor;
        [Inject] private MainSceneInstallersBootstrapper _mainSceneInstallersBootstrapper;
        [Inject] private MainSceneEventsBootstrapper _mainSceneEventsBootstrapper;
        [Inject] private MainSceneEcsBootstrapper _mainSceneEcsBootstrapper;

        private void AddBootstrapItems()
        {
            _bootstrapsExecutor.Clear();
            _bootstrapsExecutor.Add(_mainSceneInstallersBootstrapper);
            _bootstrapsExecutor.Add(_mainSceneEventsBootstrapper);
            _bootstrapsExecutor.Add(_mainSceneEcsBootstrapper);
        }
    }
}