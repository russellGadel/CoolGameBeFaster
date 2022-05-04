using System.Collections;
using Core.EventsLoader;
using CustomUI.PauseButton;
using CustomUI.PauseWindow;
using Services.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events.GameTime
{
    public class PlayerUnpauseEvent : ICustomEvent
    {
        private readonly IPauseButtonView _pauseButton;
        private readonly IGameTimeService _gameTimeService;
        private readonly IPauseWindow _pauseWindow;

        [Inject]
        public PlayerUnpauseEvent(IPauseButtonView pauseButton
            , IGameTimeService gameTimeService
            , IPauseWindow pauseWindow)
        {
            _pauseButton = pauseButton;
            _gameTimeService = gameTimeService;
            _pauseWindow = pauseWindow;
        }

        public void Execute()
        {
            _gameTimeService.Unpause();

            _pauseButton.SetPauseView();
            _pauseWindow.Close();
        }
    }
}