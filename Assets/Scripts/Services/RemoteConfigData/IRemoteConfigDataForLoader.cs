using System;
using System.Collections;

namespace Services.RemoteConfigData
{
    public interface IRemoteConfigDataForLoader
    {
        IEnumerator Load();
        event EventHandler OnConfigRequestStatusFailedEvent;
        void Reload();
    }
}