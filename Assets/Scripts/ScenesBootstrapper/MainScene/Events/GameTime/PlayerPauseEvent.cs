using System.Collections;
using Core.EventsExecutor;
using Services.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events.GameTime
{
    public class PlayerPauseEvent : ICustomEvent
    {
        private readonly IGameTimeService _gameTimeService;

        [Inject]
        public PlayerPauseEvent(IGameTimeService gameTimeService)
        {
            _gameTimeService = gameTimeService;
        }

        
        public IEnumerator Execute()
        {
            AddPauseObservers();

            yield return null;
        }

        
        private void AddPauseObservers()
        {
            _gameTimeService.AddPlayerPauseObservers(PauseObservers);
        }

        private void PauseObservers()
        {
        }

        
      
    }
}