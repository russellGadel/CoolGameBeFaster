using ECS.Components.BlockSpawnDuration;
using ECS.Components.LevelDifficultyComponent;
using ECS.Components.PointsComponents;
using ECS.Components.PositionsPool;
using ECS.Components.Rigidbody2DComponent;
using ECS.Components.TransformComponent;
using ECS.Data;
using ECS.Events;
using ECS.Tags;
using ECS.Tags.InterferingObjects.InterferingObjectsAppearingPositionsGridTag;
using ECS.Tags.InterferingObjects.InterferingObjectTag;
using ECS.Tags.Points;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Events
{
    public sealed class SpawnPointsAtRandomPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PointsTag, SpawnEvent>
            .Exclude<BlockSpawnDurationComponent> _pointsMain = null;

        private readonly EcsFilter<SpawnedPointsCounterComponent> _spawnedPointsCounter = null;
        
        private MainSceneData _mainSceneData;

        private readonly EcsFilter<InterferingObjectTag
            , LevelDifficultyComponent
            , InactiveObjectTag
            , TransformComponent
            , Rigidbody2DComponent> _inactiveInterferingObjectsElements = null;

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag
            , PositionsPoolComponent> _spawnPositions = null;


        public void Run()
        {
            throw new System.NotImplementedException();
           
        }
    }
}