using ECS.Components.BlockSpawnDuration;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events
{
    public sealed class BlockSpawnObjectsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<BlockSpawnDurationComponent> _ecsFilter = null;


        public void Run()
        {
            foreach (int i in _ecsFilter)
            {
                ref EcsEntity entity = ref _ecsFilter.GetEntity(i);
                ref BlockSpawnDurationComponent block = ref _ecsFilter.Get1(i);

                ref float timer = ref block.Timer;

                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    entity.Del<BlockSpawnDurationComponent>();
                }
            }
        }
    }
}