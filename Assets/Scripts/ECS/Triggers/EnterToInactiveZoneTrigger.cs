using ECS.Components.Entity;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class EnterToInactiveZoneTrigger : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("Enter to inactive Zone");
            EntityMono entityMono = other.gameObject.GetComponent<EntityMono>();
            entityMono.Entity.Replace(new DeactivateObjectEvent());
        }
    }
}