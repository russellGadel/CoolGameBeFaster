using Core.EventsExecutor;
using ScenesBootstrapper.LoadingScene.Events;
using ScenesLoader;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneBootstrapper : ISceneBootstrapper
    {
        //   private ILoadingWindowPresenter _loadingWindow;
        [Inject] private readonly ICustomEventsExecutor _executor;
        [Inject] private readonly ICustomScenesLoader _scenesLoader;

        public void Enter()
        {
            //   _loadingWindow.Open();

            Debug.Log("LoadingScene Enter");

            AddEnterItems();

            _executor.Execute();
        }

        public void Exit()
        {
        }

        private void AddEnterItems()
        {
            _executor.Clear();
            _executor.AddEvent(new LoadMainSceneEvent(_scenesLoader, this));
        }
    }
}