using System.Collections;
using Core.EventsLoader;
using ScenesBootstrapper.LoadingScene;
using ScenesLoader;

namespace CustomEvents
{
    public sealed class LoadMainSceneEventLoader : ICustomEventLoader
    {
        private readonly ICustomScenesLoader _scenesLoader;
        private readonly LoadingSceneBootstrapper _loadingSceneBootstrapper;
        
        public LoadMainSceneEventLoader(ICustomScenesLoader scenesLoader,
            LoadingSceneBootstrapper loadingSceneBootstrapper)
        {
            _scenesLoader = scenesLoader;
            _loadingSceneBootstrapper = loadingSceneBootstrapper;
            
            
        }

        public IEnumerator Load()
        {
            yield return _scenesLoader.LoadSceneAsync(ScenesNaming.MainScene, _loadingSceneBootstrapper);
        }
    }
}