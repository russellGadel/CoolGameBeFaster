using System.Collections;
using Core.EventsExecutor;
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

        public IEnumerator Execute()
        {
            AddUnpauseObservers();
            yield return null;
        }


        private void AddUnpauseObservers()
        {
            _gameTimeService.AddPlayerUnpauseObservers(UnpauseObservers);
        }

        private void UnpauseObservers()
        {
        }
    }
}