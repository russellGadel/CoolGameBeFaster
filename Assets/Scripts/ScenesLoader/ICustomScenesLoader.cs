using System.Collections;
using ScenesBootstrapper;

namespace ScenesLoader
{
    public interface ICustomScenesLoader
    {
        void LoadScene(ScenesNaming sceneNaming);
        IEnumerator LoadSceneAsync(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper);
    }
}