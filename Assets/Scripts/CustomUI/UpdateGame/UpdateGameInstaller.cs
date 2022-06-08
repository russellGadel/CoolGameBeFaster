using UnityEngine;
using Zenject;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGameInstaller : MonoInstaller
    {
        [SerializeField] private UpdateGameSettings _settings;

        public override void InstallBindings()
        {
            _settings.Construct();

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
        
        private IUpdateGameModel InstallModel()
        {
            return new UpdateGameModel(_settings);
        }
    }
}