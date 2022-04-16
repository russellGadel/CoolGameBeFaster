﻿using ECS.Components;
using ECS.Components.GameObjectComponent;
using ECS.Events;
using Leopotam.Ecs;

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
                
                entity.Del<ActivateObjectEvent>();
            }
        }
    }
}