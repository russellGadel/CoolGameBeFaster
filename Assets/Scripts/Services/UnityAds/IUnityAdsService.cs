using Core.InstallersExecutor;

namespace Services.UnityAds
{
    public interface IUnityAdsService : ICustomInstaller
    {
        void ShowRewardedVideo();
    }
}