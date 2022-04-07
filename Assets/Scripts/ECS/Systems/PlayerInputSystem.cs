using CustomUI.PlayerController;
using ECS.Components.DirectionComponent;
using ECS.Components.PlayerTagComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<PlayerTagComponent, DirectionComponent>
            _ecsFilter = null;

        private readonly IPlayerControllerPresenter _playerController;

        public void Run()
        {
            foreach (var entity in _ecsFilter)
            {
                ref DirectionComponent directionComponent = ref _ecsFilter.Get2(entity);
                ref Vector3 direction = ref directionComponent.direction;

                direction.x = _playerController.GetInputVector().x;
                direction.y = _playerController.GetInputVector().y;
            }
        }
    }
}