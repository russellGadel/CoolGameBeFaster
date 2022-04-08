using System.Collections.Generic;
using ECS.Components.Camera.CameraCornersComponent;
using ECS.Components.PositionsPool;
using ECS.Data;
using ECS.Data.Camera;
using Leopotam.Ecs;
using Unity.Mathematics;

namespace ECS.Systems
{
    public class LoadPositionsPoolSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<CameraBorderCornersComponent, PositionsPoolComponent>
            _ecsFilter = null;

        private readonly MainSceneData _mainSceneData;

        public void Init()
        {
            foreach (var entity in _ecsFilter)
            {
                ref CameraBorderCornersComponent cameraBorderCornersComponent = ref _ecsFilter.Get1(entity);
                ref PositionsPoolComponent positionsPoolComponent = ref _ecsFilter.Get2(entity);

                ref List<float3> positionsPool = ref positionsPoolComponent.Positions;
                ref CameraData cameraData = ref _mainSceneData.cameraData;

                FillLeftBorderSidePositions(cameraBorderCornersComponent.topLeftCorner, ref positionsPool,
                    ref cameraData);
                FillTopBorderSidePositions(cameraBorderCornersComponent.topLeftCorner, ref positionsPool,
                    ref cameraData);
                FillBottomBorderSidePositions(cameraBorderCornersComponent.bottomRightCorner, ref positionsPool,
                    ref cameraData);
                FillRightBorderSidePositions(cameraBorderCornersComponent.bottomRightCorner, ref positionsPool,
                    ref cameraData);
            }
        }

        private void FillLeftBorderSidePositions(float3 topLeftCorner, ref List<float3> positionsPool,
            ref CameraData cameraData)
        {
            float startXPoint = topLeftCorner.x - cameraData.indentOutOfCameraBorder;

            float startYPoint = topLeftCorner.y;
            float endYPoint = topLeftCorner.y - cameraData.lengthOfSides;

            while (startYPoint >= endYPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startYPoint -= cameraData.distanceBetweenPositions;
            }
        }

        private void FillTopBorderSidePositions(float3 topLeftCorner, ref List<float3> positionsPool,
            ref CameraData cameraData)
        {
            float startYPoint = topLeftCorner.y + cameraData.indentOutOfCameraBorder;

            float startXPoint = topLeftCorner.x;
            float endXPoint = topLeftCorner.x + cameraData.lengthOfSides;

            while (startXPoint <= endXPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startXPoint += cameraData.distanceBetweenPositions;
            }
        }

        private void FillBottomBorderSidePositions(float3 bottomRightCorner, ref List<float3> positionsPool,
            ref CameraData cameraData)
        {
            float startYPoint = bottomRightCorner.y - cameraData.indentOutOfCameraBorder;

            float startXPoint = bottomRightCorner.x - cameraData.lengthOfSides;
            float endXPoint = bottomRightCorner.x;

            while (startXPoint <= endXPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startXPoint += cameraData.distanceBetweenPositions;
            }
        }

        private void FillRightBorderSidePositions(float3 bottomRightCorner, ref List<float3> positionsPool,
            ref CameraData cameraData)
        {
            float startXPoint = bottomRightCorner.x + cameraData.indentOutOfCameraBorder;

            float startYPoint = bottomRightCorner.y;
            float endYPoint = bottomRightCorner.y + cameraData.lengthOfSides;

            while (startYPoint <= endYPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startYPoint += cameraData.distanceBetweenPositions;
            }
        }
    }
}