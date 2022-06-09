using System;
using System.Collections;
using Services.InternetConnection;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Services.UnityAds
{
    public sealed class UnityAdsService : MonoBehaviour
        , IUnityAdsInitializationListener
        , IUnityAdsLoadListener
        , IUnityAdsShowListener
        , IUnityAdsService
    {
        private UnityAdsSettings _settings;
        private IInternetConnectionService _internetConnectionService;

        public void Construct(in UnityAdsSettings settings
            , in IInternetConnectionService internetConnectionService)
        {
            _internetConnectionService = internetConnectionService;
            _settings = settings;
        }

        public IEnumerator Install()
        {
            InitializeUnityAds();
            yield return new WaitWhile(() => Advertisement.isInitialized == false);
            LoadAdvertisements(_settings.PlacementId);

            yield return null;
        }

        public void ShowRewardedVideo()
        {
            Advertisement.Show(_settings.PlacementId, this);
        }

        private void InitializeUnityAds()
        {
            Advertisement.Initialize(_settings.GameId, _settings.isTestMode, this);
        }


        void IUnityAdsInitializationListener.OnInitializationComplete()
        {
        }

        void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            _internetConnectionService
                .CheckInternetConnection(InitializeUnityAds
                    , null);
        }


        private void LoadAdvertisements(string placementId)
        {
            Advertisement.Load(placementId, this);
        }

        void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
        {
        }

        void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            _internetConnectionService
                .CheckInternetConnection(() => LoadAdvertisements(placementId)
                    , null);
        }


        void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            _internetConnectionService
                .CheckInternetConnection(ShowRewardedVideo
                    , null);
        }

        void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
        {
        }

        void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
        {
        }

        private event Action CompletedWatchingRewardedVideoEvent;

        public void SubscribeToCompletedWatchingRewardedVideo(Action observer)
        {
            CompletedWatchingRewardedVideoEvent += observer;
        }

        public void UnsubscribeFromCompletedWatchingRewardedVideo(Action observer)
        {
            CompletedWatchingRewardedVideoEvent -= observer;
        }

        void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId,
            UnityAdsShowCompletionState showCompletionState)
        {
            if (placementId == _settings.PlacementId)
            {
                switch (showCompletionState)
                {
                    case UnityAdsShowCompletionState.SKIPPED:
                        break;
                    case UnityAdsShowCompletionState.COMPLETED:
                        CompletedWatchingRewardedVideoEvent?.Invoke();
                        break;
                    case UnityAdsShowCompletionState.UNKNOWN:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(showCompletionState), showCompletionState, null);
                }
            }

            LoadAdvertisements(placementId);
        }
    }
}