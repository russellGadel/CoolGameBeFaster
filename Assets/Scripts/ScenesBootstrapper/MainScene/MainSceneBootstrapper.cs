using Core.BootstrapExecutor;
using Zenject;

namespace ScenesBootstrapper.MainScene
{
    public sealed class MainSceneBootstrapper : ISceneBootstrapper
    {
        public void Enter()
        {
            AddEnterItems();
            _executor.Execute();
        }

        public void Exit()
        {
        }

        [Inject] private IBootstrapExecutor _executor;
        [Inject] private UIBootstrapperMainScene _uiBootstrapperMainScene;
        [Inject] private EscBootstrapperMainScene _escBootstrapperMainScene;

        private void AddEnterItems()
        {
            _executor.Clear();
            _executor.Add(_uiBootstrapperMainScene);
            _executor.Add(_escBootstrapperMainScene);
        }
    }
}