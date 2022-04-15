using ECS.Components.GameObjectComponent;
using ECS.Components.PlayerTag;
using ECS.Components.Rigidbody2DComponent;
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
        private readonly EcsFilter<LookAtPlayerEvent, TransformComponent, Rigidbody2DComponent> _objects = null;

        public void Run()
        {
            foreach (var idx in _objects)
            {
                ref EcsEntity objectEntity = ref _objects.GetEntity(idx);
                ref TransformComponent objectsTransform = ref _objects.Get2(idx);
                ref TransformComponent playerTransform = ref _player.Get2(0);
                ref Rigidbody2DComponent objectRigidbody2D = ref _objects.Get3(idx);

                objectRigidbody2D.value.LookAt2D(playerTransform.value.position);

                objectEntity.Del<LookAtPlayerEvent>();
            }
        }
    }
}