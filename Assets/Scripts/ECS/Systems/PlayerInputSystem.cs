using CustomUI.PlayerController;
using ECS.Components.Direction;
using ECS.Tags.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent>
            _ecsFilter = null;

        private readonly IPlayerControllerPresenter _playerController = null;

        public void Run()
        {
            foreach (int entity in _ecsFilter)
            {
                ref DirectionComponent directionComponent = ref _ecsFilter.Get2(entity);
                ref Vector3 direction = ref directionComponent.Direction;

                direction = _playerController.GetInputVector();
            }
        }
    }
}