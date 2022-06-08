using ECS.Events;
using ECS.Tags;
using ECS.Tags.Point;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    public sealed class DeactivateAllActivePointsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DeactivateActivePointsEvent> _deactivatePointsEvent = null;
        private readonly EcsFilter<PointTag, ActiveObjectTag> _points = null;

        public void Run()
        {
            foreach (int idxEvent in _deactivatePointsEvent)
            {
                foreach (int idxElements in _points)
                {
                    ref EcsEntity pointEntity =
                        ref _points.GetEntity(idxElements);

                    pointEntity.Replace(new DeactivateObjectEvent());
                }

                ref EcsEntity pointsEntity = ref _deactivatePointsEvent.GetEntity(idxEvent);
                pointsEntity.Del<DeactivateActivePointsEvent>();
            }
        }
    }
}