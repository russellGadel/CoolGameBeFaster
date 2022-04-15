using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.Rigidbody2DComponent
{
    public class Rigidbody2DComponentMono : MonoBehaviour
    {
        private EntityMono _entity;
        
        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponent);
        }
        
        [SerializeField] private Rigidbody2D _rigidbody2D;
        private void AddComponent()
        {
            Rigidbody2DComponent component = new Rigidbody2DComponent()
            {
                value = _rigidbody2D
            };
            
            _entity.Entity.Replace(component);
        }
    }
}