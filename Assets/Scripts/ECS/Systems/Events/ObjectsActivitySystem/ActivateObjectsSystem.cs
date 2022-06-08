using ECS.Components.GameObjectComponent;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems.Events.ObjectsActivitySystem
{
    public sealed class ActivateObjectsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ActivateObjectEvent, GameObjectComponent> _objects = null;

        public void Run()
        {
            foreach (int idx in _objects)
            {
                ref EcsEntity entity = ref _objects.GetEntity(idx);

                entity.Del<InactiveObjectTag>();
                entity.Get<ActiveObjectTag>();

                ref GameObjectComponent gameObjectComponent = ref _objects.Get2(idx);
                gameObjectComponent.gameObject.SetActive(true);

                entity.Del<ActivateObjectEvent>();
            }
        }
    }
}