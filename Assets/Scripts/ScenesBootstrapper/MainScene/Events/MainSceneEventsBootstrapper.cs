using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsExecutor;
using ScenesBootstrapper.MainScene.Events.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class MainSceneEventsBootstrapper : IBootstrapper
    {
        public IEnumerator Execute()
        {
            AddEvents();
            yield return null;
        }

        [Inject] private readonly ICustomEventsExecutor _eventsExecutor;

        [Inject] private readonly PlayerPauseEvent _playerPauseEvent;
        [Inject] private readonly PlayerUnpauseEvent _playerUnpauseEvent;

        private void AddEvents()
        {
            _eventsExecutor.Clear();
            _eventsExecutor.AddEvent(_playerPauseEvent);
            _eventsExecutor.AddEvent(_playerUnpauseEvent);
        }
    }
}