using ECS.Components.Direction;
using ECS.Components.DynamicRigidbody2D;
using ECS.Components.PlayerTag;
using ECS.Components.Speed;
using ECS.Components.TransformComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTagComponent, TransformComponent, DynamicRigidbody2DComponent, SpeedComponent,
                DirectionComponent>
            _ecsFilter = null;

        public void Run()
        {
            foreach (var entity in _ecsFilter)
            {
                ref TransformComponent transformComponent = ref _ecsFilter.Get2(entity);
                ref DynamicRigidbody2DComponent rigidbody2DComponent = ref _ecsFilter.Get3(entity);
                ref SpeedComponent speedComponent = ref _ecsFilter.Get4(entity);
                ref DirectionComponent directionComponent = ref _ecsFilter.Get5(entity);

                ref Transform transform = ref transformComponent.value;

                ref Rigidbody2D rigidbody = ref rigidbody2DComponent.value;
                ref float speed = ref speedComponent.value;

                ref Vector3 direction = ref directionComponent.Direction;


                rigidbody.AddForce(direction * speed);
            }
        }
    }
}