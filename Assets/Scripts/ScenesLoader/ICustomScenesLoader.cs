using System.Collections;
using ScenesBootstrapper;

namespace ScenesLoader
{
    public interface ICustomScenesLoader
    {
        IEnumerator LoadScene(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper);
        IEnumerator LoadSceneAsync(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper);
        bool IsLoaded(ScenesNaming sceneName);
    }
}