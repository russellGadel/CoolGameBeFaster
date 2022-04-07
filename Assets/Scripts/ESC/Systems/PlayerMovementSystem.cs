using ESC.Components.DirectionComponent;
using ESC.Components.MovableComponent;
using ESC.Components.PlayerTagComponent;
using ESC.Components.TransformComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ESC.Systems
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<PlayerTagComponent, TransformComponent, MovableComponent, DirectionComponent>
            _ecsFilter = null;

        public void Run()
        {
            foreach (var entity in _ecsFilter)
            {
                ref TransformComponent transformComponent = ref _ecsFilter.Get2(entity);
                ref MovableComponent movableComponent = ref _ecsFilter.Get3(entity);
                ref DirectionComponent directionComponent = ref _ecsFilter.Get4(entity);

                ref Transform transform = ref transformComponent.transform;

                ref Rigidbody2D rigidbody = ref movableComponent.rigidbody;
                ref float speed = ref movableComponent.speed;

                ref Vector3 direction = ref directionComponent.direction;
                
                rigidbody.AddForce(direction * speed);
            }
        }
    }
}