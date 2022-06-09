using ECS.Components.EntityReference;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Triggers
{
    public class PlayerGetPointTrigger : MonoBehaviour
    {
        [SerializeField] private MonoEntity _playerMonoEntity;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag(UnityTags.Point.ToString()))
            {
                _playerMonoEntity.Entity.Replace(new PlayerGetPointEvent());

                MonoEntity pointMonoEntity = col.gameObject.GetComponent<MonoEntity>();
                pointMonoEntity.Entity.Replace(new DeactivateObjectEvent());
            }
        }
    }
}