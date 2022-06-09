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
            .Exclude<BlockSpawnDurationComponent> _spawnInterferingObjectsEvent = null;

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
            foreach (int idxEvent in _spawnInterferingObjectsEvent)
            {
                GetSpawnedPointsAmount(out double points);
                GetLevelDifficulty(in points, out LevelDifficulty levelDifficulty);

                GetSpawnObjectsRandomAmountAtSameTime(in levelDifficulty, out int spawnObjectsAmountAtSameTime);

                ref PositionsPoolComponent positionsPoolComponent = ref _spawnPositions.Get2(0);
                ref List<float3> positions = ref positionsPoolComponent.Positions;

                int spawnedObjectsCounter = 0;
                foreach (var idxElements in _inactiveInterferingObjectsElements)
                {
                    ref EcsEntity interferingObjectEntity =
                        ref _inactiveInterferingObjectsElements.GetEntity(idxElements);

                    ref TransformComponent interferingObjectsTransform =
                        ref _inactiveInterferingObjectsElements.Get4(idxElements);

                    interferingObjectsTransform.value.position = GetRandomPosition(in positions);

                    ZeroingInterferingObjectRotation(in idxElements);

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

                ref EcsEntity entity = ref _spawnInterferingObjectsEvent.GetEntity(idxEvent);
                entity.Get<BlockSpawnDurationComponent>().Timer =
                    GetInterferingObjectsRandomSpawnDelay(in levelDifficulty);
            }
        }

        private void GetSpawnedPointsAmount(out double points)
        {
            ref SpawnedPointsCounterComponent pointsComponent = ref _spawnedPointsCounter.Get2(0);
            points = pointsComponent.Value;
        }

        private void GetLevelDifficulty(in double points, out LevelDifficulty levelDifficulty)
        {
            levelDifficulty = _mainSceneServices
                .LevelDifficultyService
                .GetDifficulty(in points);
        }


        private void GetSpawnObjectsRandomAmountAtSameTime(in LevelDifficulty levelDifficulty,
            out int spawnObjectsAmountAtSameTime)
        {
            spawnObjectsAmountAtSameTime = Random.Range(levelDifficulty.spawnInterferingObjectsAmountAtSameTimeMin,
                levelDifficulty.spawnInterferingObjectsAmountAtSameTimeMax);
        }

        private Vector3 GetRandomPosition(in List<float3> positions)
        {
            return positions[Random.Range(0, positions.Count)];
        }

        private void ZeroingInterferingObjectRotation(in int idxElements)
        {
            ref Rigidbody2DComponent interferingObjectsRigidbody =
                ref _inactiveInterferingObjectsElements.Get5(idxElements);
            interferingObjectsRigidbody.value.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        private float GetInterferingObjectsRandomSpawnDelay(in LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.interferingObjectsSpawnDelayMin,
                levelDifficulty.interferingObjectsSpawnDelayMax);
        }
    }
}