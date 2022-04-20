using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace CustomUI.AttemptToPlay
{
    public class AttemptToPlayViewInstaller : MonoInstaller
    {
        [SerializeField] private AttemptToPlayView _view;

        public override void InstallBindings()
        {
            Container.Bind<IAttemptToPlayView>().FromInstance(_view).AsSingle();
        }
    }
}