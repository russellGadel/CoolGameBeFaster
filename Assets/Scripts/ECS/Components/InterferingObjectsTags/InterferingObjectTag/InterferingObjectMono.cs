using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.InterferingObjectsTags.InterferingObjectTag
{
    [RequireComponent(typeof(EntityMono))]
    public class InterferingObjectMono : MonoBehaviour
    {
        private EntityMono _entity;
        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponents);
        }

        private void AddComponents()
        {
            _entity.Entity.Get<InterferingObjectTag>();
        }
    }
}