using ECS.Components.EntityReference;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class PlayerGetPointTrigger : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(UnityTags.Point.ToString()))
            {
                MonoEntity pointMonoEntity = col.gameObject.GetComponent<MonoEntity>();
                pointMonoEntity.Entity.Replace(new DeactivateObjectEvent());

                MonoEntity playerMonoEntity = gameObject.GetComponent<MonoEntity>();
                playerMonoEntity.Entity.Replace(new PlayerGetPointEvent());
            }
        }
    }
}