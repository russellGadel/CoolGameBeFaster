using Core.EventsLoader;
using ScenesBootstrapper.LoadingScene.Events;
using ScenesLoader;
using UnityEngine;
using Zenject;

namespace ScenesBootstrapper.LoadingScene
{
    public sealed class LoadingSceneBootstrapper : ISceneBootstrapper
    {
        //   private ILoadingWindowPresenter _loadingWindow;
        [Inject] private readonly ICustomEventsLoader _loader;
        [Inject] private readonly ICustomScenesLoader _scenesLoader;

        public void Enter()
        {
            //   _loadingWindow.Open();

            Debug.Log("LoadingScene Enter");

            AddEnterItems();

            _loader.Load();
        }

        public void Exit()
        {
        }

        private void AddEnterItems()
        {
            _loader.Clear();
            _loader.AddEvent(new LoadMainSceneEventLoader(_scenesLoader, this));
        }
    }
}