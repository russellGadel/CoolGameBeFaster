using ECS.Components.Direction;
using ECS.Components.Rigidbody2DComponent;
using ECS.Components.Speed;
using ECS.Tags.DynamicRigidbody2D;
using ECS.Tags.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public sealed class PlayerMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag
                , DynamicRigidbody2DTag
                , Rigidbody2DComponent
                , SpeedComponent
                , DirectionComponent>
            _ecsFilter = null;

        public void Run()
        {
            foreach (var entity in _ecsFilter)
            {
                ref Rigidbody2DComponent rigidbody2DComponent = ref _ecsFilter.Get3(entity);
                ref SpeedComponent speedComponent = ref _ecsFilter.Get4(entity);
                ref DirectionComponent directionComponent = ref _ecsFilter.Get5(entity);
                
                ref Rigidbody2D rigidbody = ref rigidbody2DComponent.value;
                ref float speed = ref speedComponent.value;

                ref Vector3 direction = ref directionComponent.Direction;


                rigidbody.AddForce(direction * speed);

            }
        }
    }
}