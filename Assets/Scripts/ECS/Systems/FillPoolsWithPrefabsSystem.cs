using ECS.Components.Pool;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems
{
    public class FillPoolsWithPrefabsSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PoolComponent> _pools = null;

        public FillPoolsWithPrefabsSystem()
        {
            _world = null;
        }

        public void Init()
        {
            GameObject instantiatedObject;

            foreach (var entity in _pools)
            {
                ref PoolComponent poolComponent = ref _pools.Get1(entity);

                ref GameObject[] pool = ref poolComponent.pool;
                ref GameObject prefab = ref poolComponent.prefab;
                ref int elementsAmount = ref poolComponent.elementsAmount;
                ref Transform transform = ref poolComponent.transform;

                pool = new GameObject[elementsAmount];

                for (int i = 0; i < elementsAmount; i++)
                {
                    instantiatedObject = Object.Instantiate(prefab, transform);
                    pool[i] = instantiatedObject;
                }
            }
        }
    }
}