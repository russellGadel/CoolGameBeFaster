using ECS.Components.Entity;
using ECS.Components.KinematicRigidbody2D;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.DynamicRigidbody2D
{
    public class DynamicRigidbody2DComponentMono : MonoBehaviour
    {
        private EntityMono _entity;
        
        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponents);
        }
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private void AddComponents()
        {
            DynamicRigidbody2DComponent rigidbody2DComponent = new DynamicRigidbody2DComponent()
            {
                value = _rigidbody2D
            };
            
            _entity.Entity.Replace<DynamicRigidbody2DComponent>(rigidbody2DComponent);
        }
    }
}