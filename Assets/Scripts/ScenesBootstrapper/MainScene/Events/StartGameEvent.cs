using System.Collections;
using Core.BootstrapExecutor;
using CustomUI.PlayerController;
using CustomUI.UpperGamePlayPanel;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class StartGameEvent : IBootstrapper
    {
        private readonly IUpperGamePlayPanelView _upperGamePlayPanelView;
        private readonly IPlayerControllerPresenter _playerControllerPresenter;

        [Inject]
        private StartGameEvent(IUpperGamePlayPanelView upperGamePlayPanelView,
            IPlayerControllerPresenter playerControllerPresenter)
        {
            _upperGamePlayPanelView = upperGamePlayPanelView;
            _playerControllerPresenter = playerControllerPresenter;
        }

        IEnumerator IBootstrapper.Execute()
        {
            _upperGamePlayPanelView.Open();
            _playerControllerPresenter.OpenView();
            yield return null;
        }
    }
}