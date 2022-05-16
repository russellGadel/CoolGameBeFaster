using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace Services.InternetConnection
{
    public sealed class InternetConnectionModel : IInternetConnectionModel
    {
        private readonly InternetConnectionSettings _settings;

        public InternetConnectionModel(InternetConnectionSettings settings)
        {
            _settings = settings;
            _attemptsToConnectToServerCounter = 0;
        }

        private int _attemptsToConnectToServerCounter;

        public IEnumerator CheckInternetConnectionWithDelay()
        {
            yield return new WaitForSeconds(_settings.delayTimeForNextCheckConnectionAfterFailedAttempt);
            yield return CheckInternetConnection();
        }

        public IEnumerator CheckInternetConnection()
        {
            string url;

            if (_attemptsToConnectToServerCounter < _settings.attemptAmountToConnectToFirstURL)
            {
                url = Path.Combine(_settings.firstURLForCheckInternetConnection);
                _attemptsToConnectToServerCounter += 1;
            }
            else
            {
                url = Path.Combine(_settings.secondURLForCheckInternetConnection);
            }

            var request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Has internet Connection");

                _attemptsToConnectToServerCounter = 0;

                HasInternetConnectionEvent?.Invoke();
            }
            else
            {
                Debug.Log("Has  not internet Connection");
                HasNotInternetConnectionEvent?.Invoke();
            }
        }


        private delegate void Observer();

        private event Observer HasInternetConnectionEvent;

        public void AddOnlyOneObserverToHasInternetConnectionEvent(Action observer)
        {
            HasInternetConnectionEvent = () => observer();
        }

        private event Observer HasNotInternetConnectionEvent;

        public void AddOnlyOneObserverToHasNotInternetConnectionEvent(Action observer)
        {
            HasNotInternetConnectionEvent = () => observer();
        }
    }
}