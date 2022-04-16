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
            MonoEntity interferingObjectMonoEntity = col.gameObject.GetComponent<MonoEntity>();

            if (interferingObjectMonoEntity.Entity.Has<InterferingObjectTag>())
            {
                MonoEntity playerMonoEntity = gameObject.GetComponent<MonoEntity>();
                playerMonoEntity.Entity.Get<InterferingObjectHitPlayerEvent>();
            }
        }
    }
}