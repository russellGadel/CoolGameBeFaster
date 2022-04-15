using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.TransformComponent
{
    public class TransformComponentMono : MonoBehaviour
    {
        private EntityMono _entity;

        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponents);
        }

        [SerializeField] private Transform _transform;

        private void AddComponents()
        {
            TransformComponent transformComponent = new TransformComponent()
            {
                value = _transform
            };

            _entity.Entity.Replace<TransformComponent>(transformComponent);
        }
    }
}