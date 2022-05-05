using ECS.Components;
using ECS.Components.BlockSpawnDuration;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events.ObjectsActivitySystem
{
    public sealed class DelayDeactivateObjectSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DelayTimeDeactivateObjectComponent> _filter = null;

        public void Run()
        {
            foreach (var idx in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(idx);

                ref DelayTimeDeactivateObjectComponent delayTimeDeactivateComponent = ref _filter.Get1(idx);
                ref float timer = ref delayTimeDeactivateComponent.Timer;
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    entity.Replace(new DeactivateObjectEvent());
                    entity.Del<DelayTimeDeactivateObjectComponent>();
                }
            }
        }
    }
}