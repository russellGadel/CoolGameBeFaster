using UnityEngine;
using Zenject;

namespace CustomUI.PauseWindow
{
    public class PauseWindowInstaller : MonoInstaller
    {
        [SerializeField] private PauseWindowView _pauseWindowView;

        public override void InstallBindings()
        {
            Container
                .Bind<IPauseWindow>()
                .FromInstance(_pauseWindowView)
                .AsSingle();
        }
    }
}