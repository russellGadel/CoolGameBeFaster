using System.Collections;
using Core.EventsLoader;
using Services.Game;
using Zenject;
using RemoteConfigSettings = Services.RemoteConfigData.RemoteConfigSettings;

namespace CustomEvents
{
    public sealed class SetGameTypeEvent : ICustomEventLoader
    {
        private readonly GameSettings _gameSettings;
        private readonly RemoteConfigSettings _remoteConfigSettings;

        [Inject]
        public SetGameTypeEvent(GameSettings gameSettings
            , RemoteConfigSettings remoteConfigSettings)
        {
            _gameSettings = gameSettings;
            _remoteConfigSettings = remoteConfigSettings;
        }


        public IEnumerator Load()
        {
            switch (_gameSettings.gameTypeNaming)
            {
                case GameTypeNaming.Development:
                    SetDevelopmentState();
                    break;

                case GameTypeNaming.Production:
                    SetProductionState();
                    break;
            }

            yield return null;
        }

        private void SetDevelopmentState()
        {
            _remoteConfigSettings.SetCurrentEnvironmentId(RemoteConfigSettings.DevelopmentEnvironmentId);
        }

        private void SetProductionState()
        {
            _remoteConfigSettings.SetCurrentEnvironmentId(RemoteConfigSettings.ProductionEnvironmentId);
        }
    }
}