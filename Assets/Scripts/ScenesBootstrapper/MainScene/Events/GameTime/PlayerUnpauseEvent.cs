using System.Collections;
using Core.EventsLoader;
using Services.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events.GameTime
{
    public class PlayerUnpauseEvent : ICustomEvent
    {
        private readonly IGameTimeService _gameTimeService;

        [Inject]
        public PlayerUnpauseEvent(IGameTimeService gameTimeService)
        {
            _gameTimeService = gameTimeService;
        }

        public void Execute()
        {
            _gameTimeService.Unpause();
        }
    }
}