using System;
using System.Collections;
using Unity.RemoteConfig;
using UnityEngine;

namespace Services.RemoteConfigData
{
    public sealed class RemoteConfigData :
        IRemoteConfigDataForLoader
        , IRemoteConfigData
    {
        private struct UserAttributes
        {
        }

        private struct AppAttributes
        {
        }


        private readonly RemoteConfigSettings _settings;

        public RemoteConfigData(in RemoteConfigSettings settings)
        {
            _settings = settings;
        }


        private bool _isGetAllConfigData = false;

        public IEnumerator Load()
        {
            ConfigManager.SetEnvironmentID(_settings.CurrentEnvironmentId);
            ConfigManager.FetchCompleted += OnFetchCompleted;
            ConfigManager.FetchConfigs(new UserAttributes(), new AppAttributes());
            
            yield return new WaitUntil(() =>
                ConfigManager.requestStatus == ConfigRequestStatus.Success && _isGetAllConfigData == true);
        }

        public void Reload()
        {
            ConfigManager
                .FetchConfigs(new UserAttributes(), new AppAttributes());
        }

        public string GameVersion { get; private set; }
        public event EventHandler OnConfigRequestStatusFailedEvent;


        private void OnFetchCompleted(ConfigResponse response)
        {
            if (response.status == ConfigRequestStatus.Failed)
            {
                OnConfigRequestStatusFailed();
            }
            else
            {
                GetRemoteConfigData();
                _isGetAllConfigData = true;
            }
        }

        private void OnConfigRequestStatusFailed()
        {
            OnConfigRequestStatusFailedEvent
                ?.Invoke(this, EventArgs.Empty);
        }


        private void GetRemoteConfigData()
        {
            GameVersion = GetGameVersion();
        }

        private string GetGameVersion()
        {
            return ConfigManager
                .appConfig
                .GetString("GameVersion");
        }
    }
}