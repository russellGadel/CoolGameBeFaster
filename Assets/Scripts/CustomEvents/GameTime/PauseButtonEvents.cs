using System;
using System.Collections;
using Core.EventsLoader;
using CustomUI.PauseButton;
using Zenject;

namespace CustomEvents.GameTime
{
    public sealed class PauseButtonEvents : ICustomEventLoader
        , IDisposable
    {
        private readonly IPauseButtonView _pauseButton;
        private readonly PlayerPauseEvent _playerPauseEvent;
        private readonly PlayerUnpauseEvent _playerUnpauseEvent;


        [Inject]
        public PauseButtonEvents(IPauseButtonView pauseButton
            , PlayerPauseEvent playerPauseEvent
            , PlayerUnpauseEvent playerUnpauseEvent)
        {
            _pauseButton = pauseButton;
            _playerPauseEvent = playerPauseEvent;
            _playerUnpauseEvent = playerUnpauseEvent;
        }


        public IEnumerator Load()
        {
            SubscribeToPressPauseButtonEvent();
            yield return null;
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromPressPauseButtonEvent();
        }


        private void SubscribeToPressPauseButtonEvent()
        {
            _pauseButton.SubscribeToPressButtonEvent(PressPauseButtonEventObservers);
        }

        private void UnsubscribeFromPressPauseButtonEvent()
        {
            _pauseButton.UnsubscribeFromPressButtonEvent(PressPauseButtonEventObservers);
        }

        private int _clickPauseButtonCounter = 0;

        private void PressPauseButtonEventObservers()
        {
            _clickPauseButtonCounter += 1;

            switch (_clickPauseButtonCounter)
            {
                case 1:
                    _playerPauseEvent.Execute();
                    break;
                case 2:
                    _playerUnpauseEvent.Execute();

                    _clickPauseButtonCounter = 0;
                    break;
            }
        }
    }
}