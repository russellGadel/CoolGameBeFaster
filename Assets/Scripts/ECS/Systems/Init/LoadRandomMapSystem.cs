using ECS.Components.SetPool;
using ECS.Components.TransformComponent;
using ECS.Tags.Map;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Init
{
    public sealed class LoadRandomMapSystem : IEcsInitSystem
    {
        private readonly EcsFilter<MapTag, SetPoolComponent, TransformComponent>
            _ecsFilter = null;

        public void Init()
        {
            foreach (var entity in _ecsFilter)
            {
                ref SetPoolComponent setPool = ref _ecsFilter.Get2(entity);
                ref TransformComponent mapsPoolTransform = ref _ecsFilter.Get3(entity);

                ref GameObject[] pool = ref setPool.pool;
                GameObject randomMap = pool[RandomMapIndex(pool)];


                ref Transform mapsPool = ref mapsPoolTransform.value;
                Object.Instantiate(randomMap, mapsPool);
            }
        }

        private static int RandomMapIndex(GameObject[] pool)
        {
            return Random.Range(0, pool.Length);
        }
    }
}