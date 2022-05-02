using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class MainSceneEventsBootstrapper : IBootstrapper
    {
        public IEnumerator Execute()
        {
            AddEvents();
            _eventsLoader.Load();

            yield return null;
        }

        [Inject] private readonly ICustomEventsLoader _eventsLoader;
        [Inject] private readonly LoadSavedDataEvent _loadSavedDataEvent;
        [Inject] private AttemptToPlayEvent _attemptToPlayView;
        [Inject] private GameOverEvent _gameOverEvent;

        private void AddEvents()
        {
            _eventsLoader.Clear();
            _eventsLoader.AddEvent(_loadSavedDataEvent);
            _eventsLoader.AddEvent(_attemptToPlayView);
            _eventsLoader.AddEvent(_gameOverEvent);
        }
    }
}