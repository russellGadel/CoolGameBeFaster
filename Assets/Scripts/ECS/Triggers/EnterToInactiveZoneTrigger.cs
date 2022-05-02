using ECS.Components.EntityReference;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class EnterToInactiveZoneTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            MonoEntity monoEntity = col.gameObject.GetComponent<MonoEntity>();
            monoEntity.Entity.Replace(new DeactivateObjectEvent());
        }
    }
}