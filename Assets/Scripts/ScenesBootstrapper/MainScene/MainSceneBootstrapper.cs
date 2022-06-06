using Core.BootstrapExecutor;
using CustomEvents;
using ScenesBootstrapper.MainScene.Ecs;
using ScenesBootstrapper.MainScene.Events;
using Zenject;

namespace ScenesBootstrapper.MainScene
{
    public sealed class MainSceneBootstrapper : ISceneBootstrapper
    {
        [Inject] private readonly LoadingWindowDualEvents _loadingWindowDualEvents;

        public void Enter()
        {
            _loadingWindowDualEvents.Execute();

            AddBootstrapItems();
            AddObserversToEndBootstrap();

            _bootstrapsExecutor.Execute();
        }

        public void Exit()
        {
        }


        [Inject] private readonly IBootstrapExecutor _bootstrapsExecutor;
        [Inject] private readonly MainSceneInstallersBootstrapper _mainSceneInstallersBootstrapper;
        [Inject] private readonly MainSceneEventsBootstrapper _mainSceneEventsBootstrapper;
        [Inject] private readonly MainSceneEcsBootstrapper _mainSceneEcsBootstrapper;
        [Inject] private readonly StartGameEvent _startGameEvent;

        private void AddBootstrapItems()
        {
            _bootstrapsExecutor.Clear();
            _bootstrapsExecutor.Add(_mainSceneInstallersBootstrapper);
            _bootstrapsExecutor.Add(_mainSceneEventsBootstrapper);
            _bootstrapsExecutor.Add(_mainSceneEcsBootstrapper);
            _bootstrapsExecutor.Add(_startGameEvent);
        }


        private void AddObserversToEndBootstrap()
        {
            _bootstrapsExecutor
                .AddObserverToEndBootstrapEvent(EndBootstrapEventObservers);
        }

        private void EndBootstrapEventObservers()
        {
            _loadingWindowDualEvents.Undo();
        }
    }
}