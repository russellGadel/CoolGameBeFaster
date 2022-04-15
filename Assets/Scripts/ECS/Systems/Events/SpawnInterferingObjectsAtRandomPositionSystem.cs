using System.Collections.Generic;
using ECS.Components;
using ECS.Components.BlockSpawnDuration;
using ECS.Components.GameObjectComponent;
using ECS.Components.InterferingObjectsTags.InterferingObjectsAppearingPositionsGridTag;
using ECS.Components.InterferingObjectsTags.InterferingObjectsTag;
using ECS.Components.InterferingObjectsTags.InterferingObjectTag;
using ECS.Components.LevelDifficultyComponent;
using ECS.Components.MoveTo;
using ECS.Components.PointsComponents;
using ECS.Components.PositionsPool;
using ECS.Components.TransformComponent;
using ECS.Data;
using ECS.Events;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEditor.Tilemaps;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.Systems.Events
{
    public sealed class SpawnInterferingObjectsAtRandomPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InterferingObjectsTag, SpawnEvent>
            .Exclude<BlockSpawnDurationComponent> _interferingObjectsMain = null;

        private readonly EcsFilter<SpawnedPointsCounterComponent> _spawnedPointsCounter = null;

        private MainSceneData _mainSceneData;

        private readonly EcsFilter<InterferingObjectTag
            , LevelDifficultyComponent
            , InactiveObjectTag
            , TransformComponent> _inactiveInterferingObjectsElements = null;

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag
            , PositionsPoolComponent> _spawnPositions = null;


        public void Run()
        {
            foreach (var idxMain in _interferingObjectsMain)
            {
                var points = GetSpawnedPointsAmount();

                int spawnObjectsAmountAtSameTime = GetSpawnObjectsAmountAtSameTime(points);

                int spawnedObjectsCounter = 0;
                foreach (var idxElements in _inactiveInterferingObjectsElements)
                {
                    ref EcsEntity interferingObjectEntity =
                        ref _inactiveInterferingObjectsElements.GetEntity(idxElements);

                    ref TransformComponent interferingObjectsTransform =
                        ref _inactiveInterferingObjectsElements.Get4(idxElements);

                   // interferingObjectsTransform.value.position = GetRandomPosition();
                    Debug.Log(
                        "interferingObjectsTransform.value.position " + interferingObjectsTransform.value.position);
                    interferingObjectEntity
                       // .Replace(new SetRandomSpeedEvent())
                        //.Replace(new LookAtPlayerEvent())
                        .Replace(new ActivateObjectEvent())
                        /*.Replace(new MoveToComponent()
                        {
                            Value = interferingObjectsTransform.value.up
                        })*/;

                    spawnedObjectsCounter += 1;
                    if (spawnedObjectsCounter == spawnObjectsAmountAtSameTime)
                    {
                        break;
                    }
                }

                ref EcsEntity entity = ref _interferingObjectsMain.GetEntity(idxMain);
                entity.Get<BlockSpawnDurationComponent>().Timer = GetBlockSpawnDuration(points);
            }
        }

        private double GetSpawnedPointsAmount()
        {
            ref SpawnedPointsCounterComponent pointsComponent = ref _spawnedPointsCounter.Get1(0);
            return pointsComponent.Value;
        }

        private int GetSpawnObjectsAmountAtSameTime(double points)
        {
            return _mainSceneData
                .LevelDifficultyService
                .GetDifficulty(points)
                .spawnInterferingObjectsAmountAtSameTime;
        }


        private Vector3 GetRandomPosition()
        {
            ref PositionsPoolComponent positionsPoolComponent = ref _spawnPositions.Get2(0);
            ref List<float3> positions = ref positionsPoolComponent.Positions;
            return positions[Random.Range(0, positions.Count)];
        }

        private float GetBlockSpawnDuration(double spawnedPointsAmount)
        {
            return _mainSceneData
                .LevelDifficultyService
                .GetDifficulty(spawnedPointsAmount)
                .interferingObjectsSpawnDelay;
        }
    }
}