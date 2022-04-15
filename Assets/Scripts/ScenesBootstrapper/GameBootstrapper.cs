using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace ScenesBootstrapper
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Inject] private ISceneBootstrapper _bootstrapper;
        
        private void Awake()
        {
            _bootstrapper.Enter();
        }
    }
}