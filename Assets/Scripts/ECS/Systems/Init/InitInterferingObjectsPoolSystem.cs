using ECS.Components.GameObjectComponent;
using ECS.Events;
using ECS.Tags.InterferingObjects.InterferingObjectTag;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitInterferingObjectsPoolSystem : IEcsInitSystem
    {
        private readonly EcsFilter<InterferingObjectTag, GameObjectComponent> _interferingObjects = null;

        public void Init()
        {
            foreach (int idx in _interferingObjects)
            {
                ref EcsEntity entity = ref _interferingObjects.GetEntity(idx);
                entity.Get<DeactivateObjectEvent>();
            }            
        }
    }
}