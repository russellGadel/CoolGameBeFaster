using ECS.Components.Entity;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.LevelDifficultyComponent
{
    [RequireComponent(typeof(EntityMono))]
    public class LevelDifficultyComponentMono : MonoBehaviour
    {
        private EntityMono _entity;

        private void Awake()
        {
            _entity = GetComponent<EntityMono>();
            _entity.AddObserverToEndInitializeEvent(AddComponents);
        }

        [SerializeField] private LevelDifficultyNaming _levelDifficultyNaming;
        
        private void AddComponents()
        {
            LevelDifficultyComponent levelDifficultyComponent = new LevelDifficultyComponent()
            {
                value = _levelDifficultyNaming
            };
            
            _entity.Entity.Replace(levelDifficultyComponent);
        }
    }
}