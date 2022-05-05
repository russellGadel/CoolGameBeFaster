using UnityEngine;
using Zenject;

namespace CustomUI.StartWindow
{
    public class StartWindowInstaller : MonoInstaller
    {
        [SerializeField] private StartWindowView _startWindow;

        public override void InstallBindings()
        {
            Container
                .Bind<IStartWindowView>()
                .FromInstance(_startWindow)
                .AsSingle();
        }
    }
}