using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.Speed
{
    public class SpeedComponentMono : MonoBehaviour
    {
    private EntityMono _entity;

    private void Awake()
    {
        _entity = GetComponent<EntityMono>();
        _entity.AddObserverToEndInitializeEvent(AddComponent);
    }

    [SerializeField] private float _defaultSpeed;

    private void AddComponent()
    {
       SpeedComponent component = new SpeedComponent()
        {
            value = _defaultSpeed
        };

        _entity.Entity.Replace<SpeedComponent>(component);
    }
    }
}