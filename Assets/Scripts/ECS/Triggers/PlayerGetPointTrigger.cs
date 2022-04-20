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
                Debug.Log("Player got Point");
                //Point
                MonoEntity pointMonoEntity = col.gameObject.GetComponent<MonoEntity>();
                pointMonoEntity.Entity.Replace(new DeactivateObjectEvent());

                //Player
                MonoEntity playerMonoEntity = gameObject.GetComponent<MonoEntity>();
                playerMonoEntity.Entity.Replace(new PlayerGetPointEvent());
            }
        }
    }
}