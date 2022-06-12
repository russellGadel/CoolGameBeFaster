using System.Collections.Generic;
using ECS.Components.BlockSpawnDuration;
using ECS.Components.EntityReference;
using ECS.Components.MoveTo;
using ECS.Components.PointsComponents;
using ECS.Components.PositionsPool;
using ECS.Components.Rigidbody2DComponent;
using ECS.Components.TransformComponent;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags.InterferingObjects.InterferingObjectsAppearingPositionsGridTag;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
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

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag
            , PositionsPoolComponent> _spawnPositions = null;


        public void Run()
        {
            foreach (int idxEvent in _spawnInterferingObjectsEvent)
            {
                GetSpawnedPointsAmount(out double points);
                GetLevelDifficulty(in points, out LevelDifficulty levelDifficulty);
                Debug.Log($"levelDifficulty {levelDifficulty.name}");

                GetSpawnObjectsRandomAmountAtSameTime(in levelDifficulty, out int spawnObjectsAmountAtSameTime);

                ref PositionsPoolComponent positionsPoolComponent = ref _spawnPositions.Get2(0);
                ref List<float3> positions = ref positionsPoolComponent.Positions;

                for (int spawnedObjects = 0; spawnedObjects < spawnObjectsAmountAtSameTime; spawnedObjects++)
                {
                    GetInterferingObjectEntity(in levelDifficulty, out MonoEntity interferingObjectMonoEntity);

                    if (interferingObjectMonoEntity == null)
                    {
                        break;
                    }

                    ref TransformComponent transform = ref interferingObjectMonoEntity.Entity.Get<TransformComponent>();

                    transform.value.position = GetRandomPosition(in positions);

                    ZeroingInterferingObjectRotation(in interferingObjectMonoEntity.Entity.Get<Rigidbody2DComponent>());

                    interferingObjectMonoEntity.Entity
                        .Replace(new SetRandomSpeedEvent())
                        .Replace(new LookAtPlayerEvent())
                        .Replace(new ActivateObjectEvent())
                        .Replace(new MoveToComponent()
                        {
                            Value = transform.value.up
                        });
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


        private void GetInterferingObjectEntity(in LevelDifficulty levelDifficulty,
            out MonoEntity interferingObjectEntity)
        {
            MonoEntity entity = _mainSceneServices.InterferingObjectsService
                .GetInterferingObject(levelDifficulty.name);

            if (entity != null)
            {
                interferingObjectEntity = entity;
            }
            else
            {
                interferingObjectEntity = null;
            }
        }


        private Vector3 GetRandomPosition(in List<float3> positions)
        {
            return positions[Random.Range(0, positions.Count)];
        }

        private void ZeroingInterferingObjectRotation(in Rigidbody2DComponent interferingObjectsRigidbody)
        {
            interferingObjectsRigidbody.value.transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        private float GetInterferingObjectsRandomSpawnDelay(in LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.interferingObjectsSpawnDelayMin,
                levelDifficulty.interferingObjectsSpawnDelayMax);
        }
    }
}