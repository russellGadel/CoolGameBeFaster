using ECS.Components.MoveTo;
using ECS.Components.Rigidbody2DComponent;
using ECS.Components.Speed;
using ECS.Components.TransformComponent;
using ECS.Tags;
using ECS.Tags.KinematicRigidbody2D;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    // Fixed Update
    public class KinematicRigidbody2DMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<KinematicRigidbody2DTag, MoveToComponent
                , TransformComponent, SpeedComponent, ActiveObjectTag>
            _bodies;

        public void Run()
        {
            foreach (var idx in _bodies)
            {
                ref MoveToComponent moveToComponent = ref _bodies.Get2(idx);
                ref TransformComponent transformComponent = ref _bodies.Get3(idx);
                ref SpeedComponent speedComponent = ref _bodies.Get4(idx);

                transformComponent
                    .value
                    .Translate(moveToComponent.Value * speedComponent.value * Time.fixedDeltaTime);
            }
        }
    }
}