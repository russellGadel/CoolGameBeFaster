using UnityEngine;
using Zenject;

namespace CustomUI.UpperGamePlayPanel
{
    public class UpperGamePlayPanelInstaller : MonoInstaller
    {
        [SerializeField] public UpperGamePlayPanelView _gamePlayPanel;

        public override void InstallBindings()
        {
            Container
                .Bind<IUpperGamePlayPanelView>()
                .FromInstance(_gamePlayPanel)
                .AsSingle();
        }
    }
}