using UnityEngine;
using Zenject;

namespace CustomUI.PlayerAccelerationButton
{
    public sealed class PlayerAccelerationButtonInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindView();
            BindSettings();
        }

        [SerializeField] private PlayerAccelerationButtonView _view;

        private void BindView()
        {
            Container
                .Bind<IPlayerAccelerationButtonView>()
                .FromInstance(_view)
                .AsSingle();
        }


        [SerializeField] private PlayerAccelerationButtonSettings _settings;

        private void BindSettings()
        {
            Container
                .Bind<PlayerAccelerationButtonSettings>()
                .FromInstance(_settings)
                .AsSingle();
        }
    }
}