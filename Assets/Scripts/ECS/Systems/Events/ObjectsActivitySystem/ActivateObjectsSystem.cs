using ECS.Components;
using ECS.Components.GameObjectComponent;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events.ObjectsActivitySystem
{
    public class ActivateObjectsSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ActivateObjectEvent, GameObjectComponent> _objects = null;

        public void Run()
        {
            foreach (var idx in _objects)
            {
                ref EcsEntity entity = ref _objects.GetEntity(idx);

                entity.Del<InactiveObjectTag>();
                entity.Get<ActiveObjectTag>();
                
                ref GameObjectComponent gameObjectComponent = ref _objects.Get2(idx);
                gameObjectComponent.gameObject.SetActive(true);
                gameObjectComponent.gameObject.transform.position = new Vector3(
                    gameObjectComponent.gameObject.transform.position.x,
                    gameObjectComponent.gameObject.transform.position.y, 0);
                
                Debug   .Log("Activate " + gameObjectComponent.gameObject.transform.position);
                entity.Del<ActivateObjectEvent>();
            }
        }
    }
}