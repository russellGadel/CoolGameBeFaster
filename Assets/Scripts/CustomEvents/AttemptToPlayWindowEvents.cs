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

        public void Execute(double currentPoints, double maxPoints)
        {
            _attemptToPlayView.SetCurrentPointsAmount(currentPoints);
            _attemptToPlayView.SetMaxPointsAmount(maxPoints);

            _attemptToPlayView.Open();
        }

        public IEnumerator Load()
        {
            AddObserversToAdvertisementButton();
            AddObserverToRepeatGameButton();
            AddObserversToThenCompletedWatchingRewardedVideoEvent();

            yield return null;
        }


        private void AddObserversToAdvertisementButton()
        {
            _attemptToPlayView.AddObserverToAdvertisingButton(AdvertisingButtonObservers);
        }

        private void AdvertisingButtonObservers()
        {
            _unityAdsService.ShowRewardedVideo();
        }


        private void AddObserverToRepeatGameButton()
        {
            _attemptToPlayView.AddObserverToRepeatButton(RepeatGameButtonObservers);
        }

        private void RepeatGameButtonObservers()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new StartGameEcsEvent());

            _attemptToPlayView.Close();
        }


        private void AddObserversToThenCompletedWatchingRewardedVideoEvent()
        {
            _unityAdsService
                .AddObserverToThenFullCompletedWatchingRewardedVideoEvent
                    (ObserversOfThenCompletedWatchingRewardedVideoEvent);
        }

        private void ObserversOfThenCompletedWatchingRewardedVideoEvent()
        {
            EcsEntity entity = WorldHandler.GetWorld().NewEntity();
            entity.Replace(new ContinueGameAfterGameOverEvent());

            _attemptToPlayView.Close();
        }
    }
}