using ECS.Components.MapTagComponent;
using ECS.Components.ObjectsPoolComponent;
using ECS.Components.TransformComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class LoadRandomMapSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<MapTagComponent, ObjectsPoolComponent, TransformComponent>
            _ecsFilter = null;

        public void Init()
        {
            foreach (var entity in _ecsFilter)
            {
                ref ObjectsPoolComponent objectsPool = ref _ecsFilter.Get2(entity);
                ref TransformComponent mapsPoolTransform = ref _ecsFilter.Get3(entity);

                ref GameObject[] pool = ref objectsPool.pool;
                GameObject randomMap = pool[RandomMapIndex(pool)];


                ref Transform mapsPool = ref mapsPoolTransform.transform;
                Object.Instantiate(randomMap, mapsPool);
            }
        }

        private static int RandomMapIndex(GameObject[] pool)
        {
            return Random.Range(0, pool.Length);
        }
    }
}