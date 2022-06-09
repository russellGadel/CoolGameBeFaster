using ECS.Components.MoveTo;
using ECS.Components.Speed;
using ECS.Components.TransformComponent;
using ECS.Tags;
using ECS.Tags.KinematicRigidbody2D;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    // Fixed Update
    public sealed class KinematicRigidbody2DMovementSystem : IEcsRunSystem
    {
        private readonly EcsFilter<KinematicRigidbody2DTag, ActiveObjectTag
                , MoveToComponent, TransformComponent, SpeedComponent>
            _bodies = null;

        public void Run()
        {
            foreach (int idx in _bodies)
            {
                ref MoveToComponent moveToComponent = ref _bodies.Get3(idx);
                ref TransformComponent transformComponent = ref _bodies.Get4(idx);
                ref SpeedComponent speedComponent = ref _bodies.Get5(idx);

                transformComponent
                    .value
                    .Translate(moveToComponent.Value * speedComponent.value);
            }
        }
    }
}