using ECS.Components.GameObjectComponent;
using ECS.Events;
using ECS.Tags.InterferingObjects.InterferingObjectTag;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public class PrepareInterferingObjectsPoolSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InterferingObjectTag, GameObjectComponent> _interferingObjects = null;

        public void Init()
        {
            foreach (var idx in _interferingObjects)
            {
                ref EcsEntity entity = ref _interferingObjects.GetEntity(idx);
                entity.Get<DeactivateObjectEvent>();
            }            
        }
    }
}