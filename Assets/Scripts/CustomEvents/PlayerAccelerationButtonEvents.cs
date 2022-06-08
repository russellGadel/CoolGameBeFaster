using System;
using System.Collections;
using Core.CustomInvoker;
using Core.EventsLoader;
using CustomUI.PlayerAccelerationButton;
using ECS.Events;
using ECS.Tags.Player;
using Leopotam.Ecs;
using Voody.UniLeo;
using Zenject;

namespace CustomEvents
{
    public sealed class PlayerAccelerationButtonEvents : ICustomEventLoader
        , IDisposable
    {
        private readonly IPlayerAccelerationButtonView _playerAccelerationButton;
        private readonly PlayerAccelerationButtonSettings _playerAccelerationButtonSettings;
        private readonly ICustomInvokerService _invokerService;

        [Inject]
        private PlayerAccelerationButtonEvents(IPlayerAccelerationButtonView playerAccelerationButton,
            PlayerAccelerationButtonSettings playerAccelerationButtonSettings
            , ICustomInvokerService invokerService)
        {
            _playerAccelerationButton = playerAccelerationButton;
            _playerAccelerationButtonSettings = playerAccelerationButtonSettings;
            _invokerService = invokerService;
        }

        public IEnumerator Load()
        {
            GetPlayerEntity();

            SubscribeToOnPointerDownEvent();
            SubscribeToOnPointerUpEvent();
            yield return null;
        }

        void IDisposable.Dispose()
        {
            UnsubscribeFromOnPointerDownEvent();
            UnsubscribeFromOnPointerUpEvent();
        }


        private static EcsFilter _player = null;

        private static void GetPlayerEntity()
        {
            _player = WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>));
        }


        private void SubscribeToOnPointerDownEvent()
        {
            _playerAccelerationButton.SubscribeToOnPointerDownEvent(PointerDownOnButtonObservers);
        }

        private void UnsubscribeFromOnPointerDownEvent()
        {
            _playerAccelerationButton.UnsubscribeFromOnPointerDownEvent(PointerDownOnButtonObservers);
        }


        private int _clickAccelerationButtonCounter = 0;

        private void PointerDownOnButtonObservers()
        {
            _clickAccelerationButtonCounter += 1;

            _invokerService.CustomInvoke(ZeroingAccelerationButtonClickerCounter,
                GetDelayTime());

            switch (_clickAccelerationButtonCounter)
            {
                case 1:
                    SetFirstAccelerationSpeed();
                    break;
                case 2:
                    SetSecondAccelerationSpeed();
                    break;
            }
        }

        private void ZeroingAccelerationButtonClickerCounter()
        {
            _clickAccelerationButtonCounter = 0;
        }

        private float GetDelayTime()
        {
            return _playerAccelerationButtonSettings.delayTimeForZeroingDoubleClick;
        }

        private void SetFirstAccelerationSpeed()
        {
            _player.GetEntity(0)
                .Replace(new PlayerFirstAccelerationSpeedEvent());
        }

        private void SetSecondAccelerationSpeed()
        {
            _player.GetEntity(0)
                .Replace(new PlayerSecondAccelerationSpeedEvent());
        }


        private void SubscribeToOnPointerUpEvent()
        {
            _playerAccelerationButton.SubscribeOnPointerUpEvent(PointerUpOnButtonObservers);
        }

        private void UnsubscribeFromOnPointerUpEvent()
        {
            _playerAccelerationButton.UnsubscribeFromOnPointerUpEvent(PointerUpOnButtonObservers);
        }

        private void PointerUpOnButtonObservers()
        {
            SetNormalSpeed();
        }

        private void SetNormalSpeed()
        {
            _player.GetEntity(0)
                .Replace(new PlayerNormalSpeedEvent());
        }
    }
}