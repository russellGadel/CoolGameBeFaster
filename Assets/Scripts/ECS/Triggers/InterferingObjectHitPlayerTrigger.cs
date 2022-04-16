using ECS.Components.Entity;
using ECS.Components.EntityReference;
using ECS.Components.InterferingObjectsTags.InterferingObjectTag;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class InterferingObjectHitPlayerTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            Debug.Log("Player Hit By InterferingObject");
            EntityMono interferingObjectEntity = col.gameObject.GetComponent<EntityMono>();

            if (interferingObjectEntity.Entity.Has<InterferingObjectTag>())
            {
                EntityReferenceComponent playerEntity = gameObject.GetComponent<EntityReferenceComponent>();
                playerEntity.Entity.Get<InterferingObjectHitPlayerEvent>();
            }
        }
    }
}