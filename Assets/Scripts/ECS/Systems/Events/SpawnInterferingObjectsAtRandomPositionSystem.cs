using System.Collections.Generic;
using ECS.Components.BlockSpawnDuration;
using ECS.Components.LevelDifficultyComponent;
using ECS.Components.MoveTo;
using ECS.Components.PointsComponents;
using ECS.Components.PositionsPool;
using ECS.Components.Rigidbody2DComponent;
using ECS.Components.TransformComponent;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.InterferingObjects.InterferingObjectsAppearingPositionsGridTag;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.InterferingObjects.InterferingObjectTag;
using ECS.Tags.Points;
using Leopotam.Ecs;
using Services.LevelDifficulty;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ECS.Systems.Events
{
    public sealed class SpawnInterferingObjectsAtRandomPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<InterferingObjectsTag, SpawnEvent>
            .Exclude<BlockSpawnDurationComponent> _interferingObjectsMain = null;

        private readonly EcsFilter<PointsTag, SpawnedPointsCounterComponent> _spawnedPointsCounter = null;

        private readonly MainSceneServices _mainSceneServices = null;

        private readonly EcsFilter<InterferingObjectTag
            , LevelDifficultyComponent
            , InactiveObjectTag
            , TransformComponent
            , Rigidbody2DComponent> _inactiveInterferingObjectsElements = null;

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag
            , PositionsPoolComponent> _spawnPositions = null;


        public void Run()
        {
            foreach (var idxMain in _interferingObjectsMain)
            {
                double points = GetSpawnedPointsAmount();
                LevelDifficulty levelDifficulty = GetLevelDifficulty(points);

                int spawnObjectsAmountAtSameTime =
                    GetSpawnObjectsRandomAmountAtSameTime(ref levelDifficulty);

                int spawnedObjectsCounter = 0;
                foreach (var idxElements in _inactiveInterferingObjectsElements)
                {
                    ref EcsEntity interferingObjectEntity =
                        ref _inactiveInterferingObjectsElements.GetEntity(idxElements);

                    ref TransformComponent interferingObjectsTransform =
                        ref _inactiveInterferingObjectsElements.Get4(idxElements);

                    interferingObjectsTransform.value.position = GetRandomPosition();

                    ZeroingInterferingObjectRotation(idxElements);

                    interferingObjectEntity
                        .Replace(new SetRandomSpeedEvent())
                        .Replace(new LookAtPlayerEvent())
                        .Replace(new ActivateObjectEvent())
                        .Replace(new MoveToComponent()
                        {
                            Value = interferingObjectsTransform.value.up
                        });

                    spawnedObjectsCounter += 1;
                    if (spawnedObjectsCounter == spawnObjectsAmountAtSameTime)
                    {
                        break;
                    }
                }

                ref EcsEntity entity = ref _interferingObjectsMain.GetEntity(idxMain);
                entity.Get<BlockSpawnDurationComponent>().Timer =
                    GetInterferingObjectsRandomSpawnDelay(ref levelDifficulty);
            }
        }

        private static float GetInterferingObjectsRandomSpawnDelay(ref LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.interferingObjectsSpawnDelayMin,
                levelDifficulty.interferingObjectsSpawnDelayMax);
        }

        private static int GetSpawnObjectsRandomAmountAtSameTime(ref LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.spawnInterferingObjectsAmountAtSameTimeMin,
                levelDifficulty.spawnInterferingObjectsAmountAtSameTimeMax);
        }

        private double GetSpawnedPointsAmount()
        {
            ref SpawnedPointsCounterComponent pointsComponent = ref _spawnedPointsCounter.Get2(0);
            return pointsComponent.Value;
        }


        private Vector3 GetRandomPosition()
        {
            ref PositionsPoolComponent positionsPoolComponent = ref _spawnPositions.Get2(0);
            ref List<float3> positions = ref positionsPoolComponent.Positions;
            return positions[Random.Range(0, positions.Count)];
        }

        private void ZeroingInterferingObjectRotation(int idxElements)
        {
            ref Rigidbody2DComponent interferingObjectsRigidbody =
                ref _inactiveInterferingObjectsElements.Get5(idxElements);
            interferingObjectsRigidbody.value.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        private LevelDifficulty GetLevelDifficulty(double points)
        {
            return _mainSceneServices
                .LevelDifficultyService
                .GetDifficulty(points);
        }
    }
}