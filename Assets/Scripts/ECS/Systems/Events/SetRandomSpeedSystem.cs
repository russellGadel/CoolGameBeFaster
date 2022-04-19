using UnityEngine;
using ECS.Components.Speed;
using ECS.Components.SpeedRange;
using ECS.Events;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame
    public sealed class SetRandomSpeedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SetRandomSpeedEvent, SpeedRangeComponent, SpeedComponent> _filter = null;

        public void Run()
        {
            foreach (var idx in _filter)
            {
                ref SpeedRangeComponent speedRangeComponent = ref _filter.Get2(idx);
                ref SpeedComponent speedComponent = ref _filter.Get3(idx);

                speedComponent.value = Random.Range(speedRangeComponent.MinSpeed, speedRangeComponent.MaxSpeed);

                ref EcsEntity entity = ref _filter.GetEntity(idx);
                entity.Del<SetRandomSpeedEvent>();
            }
        }
    }
}