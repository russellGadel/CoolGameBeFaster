using ECS.Events;
using ECS.Tags;
using ECS.Tags.InterferingObjects.InterferingObjectTag;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    //One Frame
    public class DeactivateActiveInterferingObjectsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<DeactivateInterferingObjectsEvent> _deactivateInterferingObjectsEvent = null;
        private readonly EcsFilter<InterferingObjectTag, ActiveObjectTag> _interferingObjects = null;

        public void Run()
        {
            foreach (var idxMain in _deactivateInterferingObjectsEvent)
            {
                foreach (var idxElements in _interferingObjects)
                {
                    ref EcsEntity interferingObjectEntity =
                        ref _interferingObjects.GetEntity(idxElements);

                    interferingObjectEntity.Replace(new DeactivateObjectEvent());
                }

                ref EcsEntity interferingObjectsEntity = ref _deactivateInterferingObjectsEvent.GetEntity(idxMain);
                interferingObjectsEntity.Del<DeactivateInterferingObjectsEvent>();
            }
        }
    }
}