using ECS.Components.EntityReference;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class InterferingObjectHitPlayerTrigger : MonoBehaviour
    {
        [SerializeField] private MonoEntity _playerMonoEntity;
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(UnityTags.InterferingObject.ToString()))
            {
                _playerMonoEntity.Entity.Replace(new InterferingObjectHitPlayerEvent());

                MonoEntity interferingObjectEntity = col.gameObject.GetComponent<MonoEntity>();
                interferingObjectEntity.Entity.Replace(new DeactivateObjectEvent());
            }
        }
    }
}