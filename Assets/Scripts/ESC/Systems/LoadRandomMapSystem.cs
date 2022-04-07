using ESC.Components;
using ESC.Components.MapTagComponent;
using ESC.Components.ObjectsPoolComponent;
using ESC.Components.TransformComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ESC.Systems
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

                GameObject[] pool = objectsPool.pool;
                GameObject randomMap = pool[RandomMapIndex(pool)];


                Transform mapsPool = mapsPoolTransform.transform;
                Object.Instantiate(randomMap, mapsPool);
            }
        }

        private static int RandomMapIndex(GameObject[] pool)
        {
            return Random.Range(0, pool.Length);
        }
    }
}