using ECS.Components.EntityReference;
using ECS.Events;
using ECS.Tags.InterferingObjects.InterferingObjectTag;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class InterferingObjectHitPlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.tag == "InterferingObject")
            {
                Debug.Log("Player Hit By InterferingObject");

                MonoEntity playerMonoEntity = gameObject.GetComponent<MonoEntity>();
                playerMonoEntity.Entity.Get<InterferingObjectHitPlayerEvent>();
            }
        }
    }
}