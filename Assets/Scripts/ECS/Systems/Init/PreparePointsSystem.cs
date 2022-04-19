using ECS.Components.GameObjectComponent;
using ECS.Events;
using ECS.Tags.Point;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class PreparePointsSystem : IEcsInitSystem
    {
        private readonly EcsFilter<PointTag, GameObjectComponent> _points = null;

        public void Init()
        {
            foreach (var idx in _points)
            {
                ref EcsEntity entity = ref _points.GetEntity(idx);
                entity.Get<DeactivateObjectEvent>();
            }
        }
    }
}