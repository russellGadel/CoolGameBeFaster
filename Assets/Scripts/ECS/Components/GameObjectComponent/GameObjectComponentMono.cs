using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.GameObjectComponent
{
    [RequireComponent(typeof(EntityMono))]
    public class GameObjectComponentMono : MonoBehaviour
    {
        private EntityMono _entity;
        
        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponents);
        }
        
        [SerializeField] private GameObject _gameObject;
        private void AddComponents()
        {
            GameObjectComponent gameObjectComponent = new GameObjectComponent()
            {
            gameObject = _gameObject
            };
            
            _entity.Entity.Replace<GameObjectComponent>(gameObjectComponent);
        }
    }
}