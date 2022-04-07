using System.Collections;
using Core.EventsExecutor;
using ScenesLoader;

namespace ScenesBootstrapper.LoadingScene.Events
{
    public sealed class LoadMainSceneEvent : ICustomEvent
    {
        private readonly ICustomScenesLoader _scenesLoader;
        private readonly LoadingSceneBootstrapper _loadingSceneBootstrapper;
        
        public LoadMainSceneEvent(ICustomScenesLoader scenesLoader,
            LoadingSceneBootstrapper loadingSceneBootstrapper)
        {
            _scenesLoader = scenesLoader;
            _loadingSceneBootstrapper = loadingSceneBootstrapper;
            
            
        }

        public IEnumerator Execute()
        {
            yield return _scenesLoader.LoadSceneAsync(ScenesNaming.MainScene, _loadingSceneBootstrapper);
        }
    }
}