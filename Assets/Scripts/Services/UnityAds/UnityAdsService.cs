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

        public void Construct(UnityAdsSettings settings
            , IInternetConnectionService internetConnectionService)
        {
            _internetConnectionService = internetConnectionService;
            _settings = settings;
        }

        public IEnumerator Install()
        {
            try
            {
                InitializeUnityAds();
            }
            catch (Exception)
            {
                _internetConnectionService
                    .CheckInternetConnection(InitializeUnityAds
                        , null);
            }

            yield return new WaitWhile(() => Advertisement.isInitialized == false);

            LoadAdvertisements(_settings.PlacementId);

            yield return null;
        }

        public void ShowRewardedVideo()
        {
            Advertisement.Show(_settings.PlacementId, this);
        }


        public bool GetAdvertisementStatus(string placementId)
        {
            /* if (placementId == _myPlacementId1)
             {
                 return Advertisement.IsReady(placementId);
             }*/

            return false;
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
        }


        void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
        }

        void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
        {
        }

        void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
        {
        }

        private delegate void Observer();

        private event Observer ThenFullCompletedWatchingRewardedVideo;

        public void AddObserverToThenFullCompletedWatchingRewardedVideoEvent(Action observer)
        {
            ThenFullCompletedWatchingRewardedVideo += () => observer();
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
                        ThenFullCompletedWatchingRewardedVideo?.Invoke();
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