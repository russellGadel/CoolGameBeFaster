using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsLoader;
using CustomEvents;
using CustomEvents.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsBootstrapper : IBootstrapper
    {
        public IEnumerator Execute()
        {
            AddEvents();
            _eventsLoader.Load();

            yield return null;
        }

        [Inject] private readonly ICustomEventsLoader _eventsLoader;
        [Inject] private readonly LoadSavedDataEvent _loadSavedDataEvent;


        [Inject] private AttemptToPlayWindowEvents _attemptToPlayView;
        [Inject] private GameOverEvent _gameOverEvent;
        [Inject] private PauseButtonEvents _pauseButtonEvents;
        [Inject] private StartWindowEvents _startWindowEvents;
        [Inject] private PlayerAccelerationButtonEvents _playerAccelerationButtonEvents;


        private void AddEvents()
        {
            _eventsLoader.Clear();
            _eventsLoader.AddEvent(_loadSavedDataEvent);

            //

            _eventsLoader.AddEvent(_attemptToPlayView);
            _eventsLoader.AddEvent(_gameOverEvent);
            _eventsLoader.AddEvent(_pauseButtonEvents);
            _eventsLoader.AddEvent(_startWindowEvents);
            _eventsLoader.AddEvent(_playerAccelerationButtonEvents);
        }
    }
}