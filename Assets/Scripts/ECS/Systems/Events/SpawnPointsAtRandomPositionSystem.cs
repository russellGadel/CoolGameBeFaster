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
using UnityEngine;

namespace ECS.Systems.Events
{
    public sealed class SpawnPointsAtRandomPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PointsTag, SpawnEvent>
            .Exclude<BlockSpawnDurationComponent> _pointsMain = null;

        private readonly EcsFilter<SpawnedPointsCounterComponent> _spawnedPointsCounter = null;

        private readonly EcsFilter<ObjectsSpawnOnPolygonCollider2DAreaTag
            , SpawnAreaSizeComponent
            , PolygonCollider2DComponent> _spawnPositions = null;

        private MainSceneServices _mainSceneData;

        private readonly EcsFilter<PointTag
            , InactiveObjectTag
            , TransformComponent> _inactivePointsElements = null;


        public void Run()
        {
            foreach (var mainIdx in _pointsMain)
            {
                ref SpawnAreaSizeComponent spawnAreaSize = ref _spawnPositions.Get2(0);
                ref PolygonCollider2DComponent spawnAreaCollider = ref _spawnPositions.Get3(0);

                ref SpawnedPointsCounterComponent spawnedPoints = ref _spawnedPointsCounter.Get1(0);

                int spawnPointsAmountAtSameTime = GetSpawnObjectsAmountAtSameTime(spawnedPoints.Value);


                int spawnedPointsAtSameTimeCounter = 0;
                int attemptsToFindPosition = 3;
                foreach (var idxElements in _inactivePointsElements)
                {
                    ref EcsEntity pointEntity = ref _inactivePointsElements.GetEntity(idxElements);
                    ref TransformComponent pointTransform = ref _inactivePointsElements.Get3(idxElements);

                    for (int i = 0; i < attemptsToFindPosition; i++)
                    {
                        Vector3 position = GetRandomPosition(ref spawnAreaSize);

                        Debug.Log("position " + position);
                        Debug.Log("spawnAreaCollider.value.OverlapPoint(position) " +
                                  spawnAreaCollider.value.OverlapPoint(position));

                        if (spawnAreaCollider.value.OverlapPoint(position))
                        {
                            pointTransform.value.position = position;

                            pointEntity
                                .Replace(new ActivateObjectEvent());

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

                ref EcsEntity mainEntity = ref _pointsMain.GetEntity(mainIdx);
                mainEntity.Get<BlockSpawnDurationComponent>().Timer = GetBlockSpawnDuration(spawnedPoints.Value);
            }
        }

        private Vector3 GetRandomPosition(ref SpawnAreaSizeComponent spawnAreaSize)
        {
            float randomX = Random.Range(spawnAreaSize.MinX, spawnAreaSize.MaxX);
            float randomY = Random.Range(spawnAreaSize.MinY, spawnAreaSize.MaxY);

            return new Vector3(randomX, randomY, 0);
        }

        private int GetSpawnObjectsAmountAtSameTime(double points)
        {
            return _mainSceneData
                .LevelDifficultyService
                .GetDifficulty(points)
                .spawnInterferingObjectsAmountAtSameTime;
        }

        private float GetBlockSpawnDuration(double spawnedPointsAmount)
        {
            return _mainSceneData
                .LevelDifficultyService
                .GetDifficulty(spawnedPointsAmount)
                .pointsSpawnDelay;
        }
    }
}