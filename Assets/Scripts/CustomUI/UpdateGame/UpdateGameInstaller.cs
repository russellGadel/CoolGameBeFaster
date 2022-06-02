using UnityEngine;
using Zenject;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUpdateGameViewModel>()
                .FromInstance(InstallViewModel())
                .AsSingle();
        }

        [SerializeField] private UpdateGameView _view;

        private IUpdateGameViewModel InstallViewModel()
        {
            IUpdateGameViewModel viewModel = new UpdateGameViewModel(_view, InstallModel());
            return viewModel;
        }


        [SerializeField] private UpdateGameSettings _settings;

        private IUpdateGameModel InstallModel()
        {
            _settings.Construct();
            return new UpdateGameModel(_settings);
        }
    }
}