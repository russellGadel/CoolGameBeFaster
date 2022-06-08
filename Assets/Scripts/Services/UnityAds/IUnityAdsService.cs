using System;
using Core.InstallersExecutor;

namespace Services.UnityAds
{
    public interface IUnityAdsService : ICustomInstaller
    {
        void ShowRewardedVideo();
        void SubscribeToCompletedWatchingRewardedVideo(Action observer);
        void UnsubscribeFromCompletedWatchingRewardedVideo(Action observer);
    }
}