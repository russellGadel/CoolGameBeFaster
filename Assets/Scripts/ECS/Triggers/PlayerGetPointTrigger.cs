using ECS.Components.EntityReference;
using ECS.Events;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class PlayerGetPointTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Point"))
            {
                MonoEntity pointMonoEntity = col.gameObject.GetComponent<MonoEntity>();
                pointMonoEntity.Entity.Replace(new DeactivateObjectEvent());

                MonoEntity playerMonoEntity = gameObject.GetComponent<MonoEntity>();
                playerMonoEntity.Entity.Replace(new PlayerGetPointEvent());
            }
        }
    }
}