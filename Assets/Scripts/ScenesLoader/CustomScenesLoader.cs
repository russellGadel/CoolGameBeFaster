using System.Collections;
using ScenesBootstrapper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScenesLoader
{
    public sealed class CustomScenesLoader : ICustomScenesLoader
    {
        public IEnumerator LoadScene(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper)
        {
            currentSceneBootstrapper.Exit();

            SceneManager.LoadScene(sceneNaming.ToString());
            Scene scene = SceneManager.GetSceneByName(sceneNaming.ToString());

            yield return new WaitWhile(() => scene.isLoaded == false);
        }

        public IEnumerator LoadSceneAsync(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper)
        {
            currentSceneBootstrapper.Exit();

            SceneManager.LoadSceneAsync(sceneNaming.ToString());
            Scene scene = SceneManager.GetSceneByName(sceneNaming.ToString());

            yield return new WaitWhile(() => scene.isLoaded == false);
        }

        public bool IsLoaded(ScenesNaming sceneName)
        {
            return SceneManager.GetSceneByName(sceneName.ToString()).isLoaded;
        }
    }
}