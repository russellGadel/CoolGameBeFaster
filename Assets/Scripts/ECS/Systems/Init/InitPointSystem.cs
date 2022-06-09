using ECS.Components.GameObjectComponent;
using ECS.Events;
using ECS.Tags.Point;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitPointSystem : IEcsInitSystem
    {
        private readonly EcsFilter<PointTag, GameObjectComponent> _allPoints = null;

        public void Init()
        {
            foreach (int idx in _allPoints)
            {
                ref EcsEntity entity = ref _allPoints.GetEntity(idx);
                entity.Get<DeactivateObjectEvent>();
            }
        }
    }
}