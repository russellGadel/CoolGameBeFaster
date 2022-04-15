﻿using ECS.Components.GameObjectComponent;
using ECS.Components.InterferingObjectsTags.InterferingObjectTag;
using ECS.Events;
using Leopotam.Ecs;

namespace ECS.Systems
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