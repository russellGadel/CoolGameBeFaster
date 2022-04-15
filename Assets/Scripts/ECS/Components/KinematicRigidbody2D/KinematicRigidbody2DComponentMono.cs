using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.KinematicRigidbody2D
{
    public class KinematicRigidbody2DComponentMono : MonoBehaviour
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
            KinematicRigidbody2DComponent rigidbody2DComponent = new KinematicRigidbody2DComponent()
            {
                value = _rigidbody2D
            };
            
            _entity.Entity.Replace(rigidbody2DComponent);
        }
    }
}