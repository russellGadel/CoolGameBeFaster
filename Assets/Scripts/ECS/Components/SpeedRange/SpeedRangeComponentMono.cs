using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.SpeedRange
{
    public class SpeedRangeComponentMono : MonoBehaviour
    {
        private EntityMono _entity;
        
        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponent);
        }
        
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        private void AddComponent()
        {
            SpeedRangeComponent component = new SpeedRangeComponent()
            {
                MinSpeed = _minSpeed,
                MaxSpeed = _maxSpeed
            };
            
            _entity.Entity.Replace<SpeedRangeComponent>(component);
        }
    }
}