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
    public sealed class PlayerAccelerationButtonEvent : ICustomEventLoader
    {
        private readonly IPlayerAccelerationButtonView _playerAccelerationButton;
        private readonly PlayerAccelerationButtonSettings _playerAccelerationButtonSettings;
        private readonly ICustomInvokerService _invokerService;

        [Inject]
        private PlayerAccelerationButtonEvent(IPlayerAccelerationButtonView playerAccelerationButton,
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

            AddObserversToOnPointerDownEvent();
            AddObserversToOnPointerUpEvent();
            yield return null;
        }


        private static EcsFilter _player = null;

        private static void GetPlayerEntity()
        {
            _player = WorldHandler.GetWorld().GetFilter(typeof(EcsFilter<PlayerTag>));
        }


        private void AddObserversToOnPointerDownEvent()
        {
            _playerAccelerationButton.AddObserverToOnPointerDownEvent(PointerDownOnButtonObservers);
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

        private static void SetFirstAccelerationSpeed()
        {
            _player.GetEntity(0)
                .Replace(new PlayerFirstAccelerationSpeedEvent());
        }

        private static void SetSecondAccelerationSpeed()
        {
            _player.GetEntity(0)
                .Replace(new PlayerSecondAccelerationSpeedEvent());
        }


        private void AddObserversToOnPointerUpEvent()
        {
            _playerAccelerationButton.AddObserverOnPointerUpEvent(PointerUpOnButtonObservers);
        }

        private void PointerUpOnButtonObservers()
        {
            SetNormalSpeed();
        }

        private static void SetNormalSpeed()
        {
            _player.GetEntity(0)
                .Replace(new PlayerNormalSpeedEvent());
        }
    }
}