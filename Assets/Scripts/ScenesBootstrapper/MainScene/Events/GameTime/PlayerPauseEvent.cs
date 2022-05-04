using Core.EventsLoader;
using CustomUI.PauseButton;
using CustomUI.PauseWindow;
using Services.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events.GameTime
{
    public sealed class PlayerPauseEvent : ICustomEvent
    {
        private readonly IPauseButtonView _pauseButton;
        private readonly IGameTimeService _gameTimeService;
        private readonly IPauseWindow _pauseWindow;

        [Inject]
        public PlayerPauseEvent(IPauseButtonView pauseButton
            , IGameTimeService gameTimeService
            , IPauseWindow pauseWindow)
        {
            _pauseButton = pauseButton;
            _gameTimeService = gameTimeService;
            _pauseWindow = pauseWindow;
        }

        public void Execute()
        {
            _gameTimeService.Pause();

            _pauseButton.SetPlayView();
            _pauseWindow.Open();
        }
    }
}