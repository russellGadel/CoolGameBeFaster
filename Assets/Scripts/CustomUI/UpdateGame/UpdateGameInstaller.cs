using UnityEngine;
using Zenject;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IUpdateGamePresenter>()
                .FromInstance(InstallPresenter())
                .AsSingle();
        }

        [SerializeField] private UpdateGameView _view;

        private IUpdateGamePresenter InstallPresenter()
        {
            IUpdateGamePresenter presenter = new UpdateGamePresenter(_view, InstallModel());
            return presenter;
        }


        [SerializeField] private UpdateGameSettings _settings;

        private IUpdateGameModel InstallModel()
        {
            _settings.Construct();
            return new UpdateGameModel(_settings);
        }
    }
}