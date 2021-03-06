using System;
using System.Collections;
using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using ECS.Events;
using Leopotam.Ecs;
using Services.UnityAds;
using Voody.UniLeo;
using Zenject;

namespace CustomEvents
{
    public sealed class AttemptToPlayWindowEvents : ICustomEventLoader
        , IDisposable
    {
        private readonly IAttemptToPlayView _attemptToPlayView;
        private readonly IUnityAdsService _unityAdsService;

        [Inject]
        public AttemptToPlayWindowEvents(IAttemptToPlayView attemptToPlayView
            , IUnityAdsService unityAdsService)
        {
            _attemptToPlayView = attemptToPlayView;
            _unityAdsService = unityAdsService;
        }

        public void Execute(in double currentPoints, in double maxPoints)
        {
            _attemptToPlayView.SetCurrentPointsAmount(currentPoints);
            _attemptToPlayView.SetMaxPointsAmount(maxPoints);

            _attemptToPlayView.Open();
        }

        public IEnumerator Load()
        {
            SubscribeToAdvertisementButton();
            SubscribeToRepeatGameButton();
            SubscribeToCompletedWatchingRewardedVideo();

            yield return null;
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromAdvertisementButton();
            UnsubscribeFromRepeatGameButton();
            UnsubscribeFromCompletedWatchingRewardedVideo();
        }


        private void SubscribeToAdvertisementButton()
        {
            _attemptToPlayView.SubscribeToAdvertisingButton(AdvertisingButtonObservers);
        }

        private void UnsubscribeFromAdvertisementButton()
        {
            _attemptToPlayView.UnsubscribeFromAdvertisingButton(AdvertisingButtonObservers);
        }

        private void AdvertisingButtonObservers()
        {
            _unityAdsService.ShowRewardedVideo();
        }


        private void SubscribeToRepeatGameButton()
        {
            _attemptToPlayView.SubscribeToRepeatButton(RepeatGameButtonObservers);
        }

        private void UnsubscribeFromRepeatGameButton()
        {
            _attemptToPlayView.UnsubscribeFromRepeatButton(RepeatGameButtonObservers);
        }

        private void RepeatGameButtonObservers()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new StartGameEcsEvent());

            _attemptToPlayView.Close();
        }


        private void SubscribeToCompletedWatchingRewardedVideo()
        {
            _unityAdsService
                .SubscribeToCompletedWatchingRewardedVideo
                    (ObserversOfCompletedWatchingRewardedVideo);
        }

        private void UnsubscribeFromCompletedWatchingRewardedVideo()
        {
            _unityAdsService
                .UnsubscribeFromCompletedWatchingRewardedVideo
                    (ObserversOfCompletedWatchingRewardedVideo);
        }

        private void ObserversOfCompletedWatchingRewardedVideo()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new ContinueGameAfterGameOverEvent());

            _attemptToPlayView.Close();
        }
    }
}