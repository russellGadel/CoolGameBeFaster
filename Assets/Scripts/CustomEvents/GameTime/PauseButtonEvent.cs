using System.Collections;
using Core.EventsLoader;
using CustomUI.PauseButton;
using Zenject;

namespace CustomEvents.GameTime
{
    public sealed class PauseButtonEvent : ICustomEventLoader
    {
        private readonly IPauseButtonView _pauseButton;
        private readonly PlayerPauseEvent _playerPauseEvent;
        private readonly PlayerUnpauseEvent _playerUnpauseEvent;


        [Inject]
        public PauseButtonEvent(IPauseButtonView pauseButton, PlayerPauseEvent playerPauseEvent,
            PlayerUnpauseEvent playerUnpauseEvent)
        {
            _pauseButton = pauseButton;
            _playerPauseEvent = playerPauseEvent;
            _playerUnpauseEvent = playerUnpauseEvent;
        }


        public IEnumerator Load()
        {
            AddObserversToPressPauseButtonEvent();
            yield return null;
        }

        private void AddObserversToPressPauseButtonEvent()
        {
            _pauseButton.AddObserverToPressButtonEvent(PressPauseButtonEventObservers);
        }

        private int _clickPauseButtonCounter = 0;

        private void PressPauseButtonEventObservers()
        {
            _clickPauseButtonCounter += 1;

            if (_clickPauseButtonCounter == 1)
            {
                _playerPauseEvent.Execute();
            }
            else if (_clickPauseButtonCounter == 2)
            {
                _playerUnpauseEvent.Execute();

                _clickPauseButtonCounter = 0;
            }
        }
    }
}