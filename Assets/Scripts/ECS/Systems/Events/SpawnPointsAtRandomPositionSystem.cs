using ECS.Components;
using ECS.Components.BlockSpawnDuration;
using ECS.Components.PointsComponents;
using ECS.Components.PolygonCollider2DComponent;
using ECS.Components.SpawnAreaSize;
using ECS.Components.TransformComponent;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.ObjectsSpawnOnPolygonCollider2DAreaTag;
using ECS.Tags.Point;
using ECS.Tags.Points;
using Leopotam.Ecs;
using Services.LevelDifficulty;
using UnityEngine;

namespace ECS.Systems.Events
{
    public sealed class SpawnPointsAtRandomPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PointsTag, SpawnEvent>
            .Exclude<BlockSpawnDurationComponent> _spawnPointsEvents = null;

        private readonly EcsFilter<PointsTag, SpawnedPointsCounterComponent> _spawnedPointsCounter = null;

        private readonly EcsFilter<ObjectsSpawnOnPolygonCollider2DAreaTag
            , SpawnAreaSizeComponent
            , PolygonCollider2DComponent> _spawnPositions = null;

        private readonly MainSceneServices _mainSceneServices = null;

        private readonly EcsFilter<PointTag
            , InactiveObjectTag
            , TransformComponent> _inactivePointsElements = null;

        private readonly int _attemptsToFindPointPosition = 3;

        public void Run()
        {
            foreach (int idxEvent in _spawnPointsEvents)
            {
                ref SpawnAreaSizeComponent spawnAreaSize = ref _spawnPositions.Get2(0);
                ref PolygonCollider2DComponent spawnAreaCollider = ref _spawnPositions.Get3(0);

                ref SpawnedPointsCounterComponent spawnedPoints = ref _spawnedPointsCounter.Get2(0);

                GetLevelDifficulty(in spawnedPoints.Value, out LevelDifficulty levelDifficulty);

                int spawnPointsAmountAtSameTime = GetSpawnPointsRandomAmountAtSameTime(in levelDifficulty);

                int spawnedPointsAtSameTimeCounter = 0;
                foreach (int idxElements in _inactivePointsElements)
                {
                    ref EcsEntity pointEntity = ref _inactivePointsElements.GetEntity(idxElements);
                    ref TransformComponent pointTransform = ref _inactivePointsElements.Get3(idxElements);

                    for (int i = 0; i < _attemptsToFindPointPosition; i++)
                    {
                        Vector2 position = GetRandomPosition(in spawnAreaSize);

                        if (spawnAreaCollider.value.OverlapPoint(position))
                        {
                            pointTransform.value.position = position;

                            pointEntity
                                .Replace(new ActivateObjectEvent())
                                .Replace(new DelayTimeDeactivateObjectComponent()
                                {
                                    Timer = GetRandomPointLifeTime(in levelDifficulty)
                                });


                            spawnedPointsAtSameTimeCounter += 1;
                            spawnedPoints.Value += 1;

                            break;
                        }
                    }

                    if (spawnedPointsAtSameTimeCounter == spawnPointsAmountAtSameTime)
                    {
                        break;
                    }
                }

                ref EcsEntity mainEntity = ref _spawnPointsEvents.GetEntity(idxEvent);
                float timer = GetPointsRandomSpawnDelay(in levelDifficulty);
                mainEntity.Get<BlockSpawnDurationComponent>().Timer = timer;
            }
        }


        private void GetLevelDifficulty(in double points, out LevelDifficulty levelDifficulty)
        {
            levelDifficulty = _mainSceneServices
                .LevelDifficultyService
                .GetDifficulty(points);
        }

        private int GetSpawnPointsRandomAmountAtSameTime(in LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.spawnedPointsAmountAtSameTimeMin,
                levelDifficulty.spawnedPointsAmountAtSameTimeMax);
        }

        private Vector2 GetRandomPosition(in SpawnAreaSizeComponent spawnAreaSize)
        {
            float randomX = Random.Range(spawnAreaSize.MinX, spawnAreaSize.MaxX);
            float randomY = Random.Range(spawnAreaSize.MinY, spawnAreaSize.MaxY);

            return new Vector2(randomX, randomY);
        }

        private float GetRandomPointLifeTime(in LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.pointsLifeTimeMin, levelDifficulty.pointsLifeTimeMax);
        }

        private float GetPointsRandomSpawnDelay(in LevelDifficulty levelDifficulty)
        {
            return Random.Range(levelDifficulty.pointsSpawnDelayMin, levelDifficulty.pointsSpawnDelayMax);
        }
    }
}