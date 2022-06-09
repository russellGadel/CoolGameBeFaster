using System.Collections;
using ScenesBootstrapper;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ScenesLoader
{
    public sealed class CustomScenesLoader : ICustomScenesLoader
    {
        public void LoadScene(ScenesNaming sceneNaming)
        {
            SceneManager.LoadScene(sceneNaming.ToString());
        }

        public IEnumerator LoadSceneAsync(ScenesNaming sceneNaming, ISceneBootstrapper currentSceneBootstrapper)
        {
            currentSceneBootstrapper.Exit();

            SceneManager.LoadSceneAsync(sceneNaming.ToString());
            Scene scene = SceneManager.GetSceneByName(sceneNaming.ToString());

            yield return new WaitWhile(() => scene.isLoaded == false);
        }
    }
}