using ScenesLoader;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ScenesBootstrapper
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [Inject] private readonly ICustomScenesLoader _scenesLoader;
        [Inject] private readonly ISceneBootstrapper _sceneBootstrapper;

        private static bool wasAtLoadingScene = false;

        public void Awake()
        {
            if (SceneManager.GetActiveScene().name == ScenesNaming.LoadingScene.ToString())
            {
                wasAtLoadingScene = true;
                _sceneBootstrapper.Enter();
            }
            else
            {
                if (wasAtLoadingScene == true)
                {
                    _sceneBootstrapper.Enter();
                }
                else
                {
                    _scenesLoader.LoadScene(ScenesNaming.LoadingScene);
                }
            }
        }
    }
}