using ECS.Components.GameObjectComponent;
using ECS.Components.PlayerTag;
using ECS.Components.TransformComponent;
using ECS.Events;
using Extensions;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events
{
    // one Frame
    public class LookAtPlayerSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTagComponent, TransformComponent> _player = null;
        private readonly EcsFilter<LookAtPlayerEvent, TransformComponent> _objects = null;

        public void Run()
        {
            foreach (var idx in _objects)
            {
                Debug.Log("Look At Player idx " + idx);
                ref TransformComponent objectsTransform = ref _objects.Get2(idx);
                ref TransformComponent playerTransformComponent = ref _player.Get2(0);
                
                objectsTransform.value.LookAt2D(
                    objectsTransform.value.transform.up
                    , playerTransformComponent.value);

                Debug.Log("objectsTransform " + objectsTransform.value.position);
                ref EcsEntity objectEntity = ref _objects.GetEntity(idx);
                objectEntity.Del<LookAtPlayerEvent>();
            }
        }
    }
}