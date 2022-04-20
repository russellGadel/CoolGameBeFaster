using System.Collections.Generic;
using ECS.Components.CameraComponent.CameraCornersComponent;
using ECS.Components.PositionsPool;
using ECS.References;
using ECS.References.Camera;
using ECS.References.MainScene;
using ECS.Tags.InterferingObjects.InterferingObjectsAppearingPositionsGridTag;
using Leopotam.Ecs;
using Unity.Mathematics;

namespace ECS.Systems.Init
{
    public sealed class LoadPositionsPoolSystem : IEcsInitSystem
    {
        private readonly EcsFilter<CameraBorderCornersComponent> _camera = null;

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag, PositionsPoolComponent>
            _objectsPositionsPool = null;

        private readonly MainSceneData _mainSceneData;

        public void Init()
        {
            ref CameraBorderCornersComponent cameraBorderCornersComponent = ref _camera.Get1(0);

            foreach (var entity in _objectsPositionsPool)
            {
                ref PositionsPoolComponent positionsPoolComponent = ref _objectsPositionsPool.Get2(entity);

                ref List<float3> positionsPool = ref positionsPoolComponent.Positions;
                ref InterferingObjectsAppearingPositionData positionsData =
                    ref _mainSceneData.interferingObjectsAppearingPositionData;

                FillLeftBorderSidePositions(cameraBorderCornersComponent.topLeftCorner, ref positionsPool,
                    ref positionsData);
                FillTopBorderSidePositions(cameraBorderCornersComponent.topLeftCorner, ref positionsPool,
                    ref positionsData);
                FillBottomBorderSidePositions(cameraBorderCornersComponent.bottomRightCorner, ref positionsPool,
                    ref positionsData);
                FillRightBorderSidePositions(cameraBorderCornersComponent.bottomRightCorner, ref positionsPool,
                    ref positionsData);
            }
        }

        private void FillLeftBorderSidePositions(float3 topLeftCorner, ref List<float3> positionsPool,
            ref InterferingObjectsAppearingPositionData positionData)
        {
            float startXPoint = topLeftCorner.x - positionData.indentOutOfCameraBorder;

            float startYPoint = topLeftCorner.y;
            float endYPoint = topLeftCorner.y - positionData.lengthOfSides;

            while (startYPoint >= endYPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startYPoint -= positionData.distanceBetweenPositions;
            }
        }

        private void FillTopBorderSidePositions(float3 topLeftCorner, ref List<float3> positionsPool,
            ref InterferingObjectsAppearingPositionData positionData)
        {
            float startYPoint = topLeftCorner.y + positionData.indentOutOfCameraBorder;

            float startXPoint = topLeftCorner.x;
            float endXPoint = topLeftCorner.x + positionData.lengthOfSides;

            while (startXPoint <= endXPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startXPoint += positionData.distanceBetweenPositions;
            }
        }

        private void FillBottomBorderSidePositions(float3 bottomRightCorner, ref List<float3> positionsPool,
            ref InterferingObjectsAppearingPositionData positionData)
        {
            float startYPoint = bottomRightCorner.y - positionData.indentOutOfCameraBorder;

            float startXPoint = bottomRightCorner.x - positionData.lengthOfSides;
            float endXPoint = bottomRightCorner.x;

            while (startXPoint <= endXPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startXPoint += positionData.distanceBetweenPositions;
            }
        }

        private void FillRightBorderSidePositions(float3 bottomRightCorner, ref List<float3> positionsPool,
            ref InterferingObjectsAppearingPositionData positionData)
        {
            float startXPoint = bottomRightCorner.x + positionData.indentOutOfCameraBorder;

            float startYPoint = bottomRightCorner.y;
            float endYPoint = bottomRightCorner.y + positionData.lengthOfSides;

            while (startYPoint <= endYPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startYPoint += positionData.distanceBetweenPositions;
            }
        }
    }
}