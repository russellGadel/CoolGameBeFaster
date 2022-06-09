using ECS.Components.PolygonCollider2DComponent;
using ECS.Components.SpawnAreaSize;
using ECS.Tags.ObjectsSpawnOnPolygonCollider2DAreaTag;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Init
{
    public sealed class InitObjectsSpawnAreaOnPolygonCollider2D : IEcsInitSystem
    {
        private readonly EcsFilter<ObjectsSpawnOnPolygonCollider2DAreaTag, PolygonCollider2DComponent> _filter = null;

        public void Init()
        {
            foreach (int idx in _filter)
            {
                ref EcsEntity entity = ref _filter.GetEntity(idx);
                ref PolygonCollider2DComponent collider = ref _filter.Get2(idx);

                Bounds bounds = collider.value.bounds;
                
                SpawnAreaSizeComponent spawnAreaSize = new SpawnAreaSizeComponent()
                {
                    MinX = bounds.min.x,
                    MaxX = bounds.max.x,
                    MinY = bounds.min.y,
                    MaxY = bounds.max.y
                };

                entity.Replace(spawnAreaSize);
            }
        }
    }
}