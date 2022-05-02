using ECS.Components.EntityReference;
using ECS.Events;
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
                playerMonoEntity.Entity.Replace(new InterferingObjectHitPlayerEvent());

                MonoEntity interferingObjectEntity = col.gameObject.GetComponent<MonoEntity>();
                interferingObjectEntity.Entity.Replace(new DeactivateObjectEvent());
            }
        }
    }
}