using System;
using Core.InstallersExecutor;

namespace Services.UnityAds
{
    public interface IUnityAdsService : ICustomInstaller
    {
        void ShowRewardedVideo();
        void SubscribeToCompletedWatchingRewardedVideoEvent(Action observer);
        void UnsubscribeFromCompletedWatchingRewardedVideoEvent(Action observer);
    }
}