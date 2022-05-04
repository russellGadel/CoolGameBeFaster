using UnityEngine;
using Zenject;

namespace CustomUI.PauseButton
{
    public sealed class PauseButtonInstaller : MonoInstaller
    {
        [SerializeField] private PauseButtonView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<IPauseButtonView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}