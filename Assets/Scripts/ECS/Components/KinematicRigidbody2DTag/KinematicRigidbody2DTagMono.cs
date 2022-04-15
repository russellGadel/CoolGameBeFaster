using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.KinematicRigidbody2DTag
{
    public class KinematicRigidbody2DTagMono : MonoBehaviour
    {
        private EntityMono _entity;
        
        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponent);
        }
        
        private void AddComponent()
        {
            _entity.Entity.Get<KinematicRigidbody2DTag>();
        }
    }
}