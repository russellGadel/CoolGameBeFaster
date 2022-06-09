using System.Collections;
using Core.EventsLoader;
using Services.InternetConnection;
using Services.RemoteConfigData;
using Zenject;

namespace CustomEvents
{
    public sealed class RemoteConfigDataEvents : ICustomEventLoader
    {
        [Inject] private readonly IRemoteConfigDataForLoader _remoteConfigDataForLoader;
        [Inject] private readonly IInternetConnectionService _internetConnectionService;


        public IEnumerator Load()
        {
            _remoteConfigDataForLoader.OnConfigRequestStatusFailedEvent += delegate
            {
                _internetConnectionService.CheckInternetConnection(ThenHasInternetConnection,
                    null);
            };

            yield return _remoteConfigDataForLoader.Load();
        }
        
        private void ThenHasInternetConnection()
        {
            _remoteConfigDataForLoader.Reload();
        }
    }
}