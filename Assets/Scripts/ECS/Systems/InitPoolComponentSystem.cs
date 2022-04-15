using ECS.Components.Entity;
using ECS.Components.Pool;
using Leopotam.Ecs;
using UnityEngine;
namespace ECS.Systems
{
    public sealed class InitPoolComponentSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PoolComponent> _pools = null;

        public void Init()
        {
            foreach (var entity in _pools)
            {
                ref PoolComponent poolComponent = ref _pools.Get1(entity);

                FillPoolWithPrefab(ref poolComponent);
            }
        }

        private void FillPoolWithPrefab(ref PoolComponent poolComponent)
        {
            ref GameObject[] pool = ref poolComponent.pool;
            ref GameObject prefab = ref poolComponent.prefab;
            ref int elementsAmount = ref poolComponent.elementsAmount;
            ref Transform transform = ref poolComponent.transform;

            pool = new GameObject[elementsAmount];

            for (int i = 0; i < elementsAmount; i++)
            {
                pool[i] = GameObject.Instantiate(prefab.gameObject, transform);
                
                EntityMono entityMono = pool[i].GetComponent<EntityMono>();
                entityMono.Entity = _world.NewEntity();
                entityMono.EndInitialize();
            }
        }
    }
}