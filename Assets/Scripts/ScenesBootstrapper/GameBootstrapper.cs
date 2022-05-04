using UnityEngine;
using Zenject;

namespace ScenesBootstrapper
{
    public sealed class GameBootstrapper : MonoBehaviour
    {
        [Inject] private ISceneBootstrapper _bootstrapper;

        private void Awake()
        {
            _bootstrapper.Enter();
        }
    }
}