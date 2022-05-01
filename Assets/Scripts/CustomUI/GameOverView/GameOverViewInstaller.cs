using UnityEngine;
using Zenject;

namespace CustomUI.GameOverView
{
    public class GameOverViewInstaller : MonoInstaller
    {
        [SerializeField] private GameOverView _view;

        public override void InstallBindings()
        {
            Container
                .Bind<IGameOverView>()
                .FromInstance(_view)
                .AsSingle();
        }
    }
}