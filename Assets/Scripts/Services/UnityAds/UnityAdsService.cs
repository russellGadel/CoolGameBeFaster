using System;
using System.Collections;
using Services.InternetConnection;
using UnityEngine;
using UnityEngine.Advertisements;

namespace Services.UnityAds
{
    public sealed class UnityAdsService : MonoBehaviour
        , IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
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
            Debug.Log("Ads Initialized");
            try
            {
                InitializeUnityAds();
            }
            catch (Exception)
            {
                Debug.Log("Has Error then Initialize UnityAds");
                _internetConnectionService
                    .CheckInternetConnection(InitializeUnityAds
                        , null);
            }

            yield return new WaitWhile(() => Advertisement.isInitialized == false);
            LoadAdvertisements();
            yield return null;
        }


        public void ShowRewardedVideo()
        {
            Advertisement.Show(_settings.PlacementId);
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
            Debug.Log("ads loaded");
            Advertisement.Initialize(_settings.GameId, _settings.isTestMode);
        }


        void IUnityAdsInitializationListener.OnInitializationComplete()
        {
            throw new System.NotImplementedException();
        }

        void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            throw new System.NotImplementedException();
        }


        private void LoadAdvertisements()
        {
            Advertisement.Load(_settings.PlacementId);
        }

        void IUnityAdsLoadListener.OnUnityAdsAdLoaded(string placementId)
        {
            throw new System.NotImplementedException();
        }

        void IUnityAdsLoadListener.OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            throw new System.NotImplementedException();
        }


        void IUnityAdsShowListener.OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            throw new System.NotImplementedException();
        }

        void IUnityAdsShowListener.OnUnityAdsShowStart(string placementId)
        {
            throw new System.NotImplementedException();
        }

        void IUnityAdsShowListener.OnUnityAdsShowClick(string placementId)
        {
            throw new System.NotImplementedException();
        }

        void IUnityAdsShowListener.OnUnityAdsShowComplete(string placementId,
            UnityAdsShowCompletionState showCompletionState)
        {
            Debug.Log("OnUnityAdsDidFinish");
            if (placementId == _settings.PlacementId)
            {
                Debug.Log("_myPlacementId1");

                switch (showCompletionState)
                {
                    case UnityAdsShowCompletionState.SKIPPED:
                        break;
                    case UnityAdsShowCompletionState.COMPLETED:
                        break;
                    case UnityAdsShowCompletionState.UNKNOWN:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(showCompletionState), showCompletionState, null);
                }
            }

            Advertisement.Load(placementId);
        }
    }
}