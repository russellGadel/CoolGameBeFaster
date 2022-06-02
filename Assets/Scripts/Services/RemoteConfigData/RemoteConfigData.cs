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

        public IEnumerator Load()
        {
            ConfigManager.FetchCompleted += OnFetchCompleted;
            ConfigManager.FetchConfigs(new UserAttributes(), new AppAttributes());

            yield return new WaitUntil(() => ConfigManager.requestStatus == ConfigRequestStatus.Success);
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
            Debug.Log($"On fetch completed ConfigRequestStatus: {response.status}");

            if (response.status == ConfigRequestStatus.Failed)
            {
                OnConfigRequestStatusFailed();
            }
            else
            {
                GetRemoteConfigData();
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

        private static string GetGameVersion()
        {
            return ConfigManager
                .appConfig
                .GetString("GameVersion");
        }
    }
}