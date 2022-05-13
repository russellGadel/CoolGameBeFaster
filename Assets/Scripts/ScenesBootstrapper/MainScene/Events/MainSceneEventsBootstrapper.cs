using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsLoader;
using ScenesBootstrapper.MainScene.Events.GameTime;
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


        [Inject] private AttemptToPlayEvent _attemptToPlayView;
        [Inject] private GameOverEvent _gameOverEvent;
        [Inject] private PauseButtonEvent _pauseButtonEvent;
        [Inject] private StartWindowEvent _startWindowEvent;
        [Inject] private PlayerAccelerationButtonEvent _playerAccelerationButtonEvent;


        private void AddEvents()
        {
            _eventsLoader.Clear();
            _eventsLoader.AddEvent(_loadSavedDataEvent);

            //

            _eventsLoader.AddEvent(_attemptToPlayView);
            _eventsLoader.AddEvent(_gameOverEvent);
            _eventsLoader.AddEvent(_pauseButtonEvent);
            _eventsLoader.AddEvent(_startWindowEvent);
            _eventsLoader.AddEvent(_playerAccelerationButtonEvent);
        }
    }
}