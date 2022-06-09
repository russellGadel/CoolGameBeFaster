using System.Collections.Generic;
using ECS.Components.CameraComponent.CameraCornersComponent;
using ECS.Components.PositionsPool;
using ECS.References.Camera;
using ECS.References.MainScene;
using ECS.Tags.InterferingObjects.InterferingObjectsAppearingPositionsGridTag;
using Leopotam.Ecs;
using Unity.Mathematics;

namespace ECS.Systems.Init
{
    public sealed class InitPositionsPoolSystem : IEcsInitSystem
    {
        private readonly EcsFilter<CameraBorderCornersComponent> _camera = null;

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag, PositionsPoolComponent>
            _objectsPositionsPool = null;

        private readonly MainSceneData _mainSceneData = null;

        public void Init()
        {
            ref CameraBorderCornersComponent cameraBorderCornersComponent = ref _camera.Get1(0);

            foreach (int entity in _objectsPositionsPool)
            {
                ref PositionsPoolComponent positionsPoolComponent = ref _objectsPositionsPool.Get2(entity);

                ref List<float3> positionsPool = ref positionsPoolComponent.Positions;
                ref InterferingObjectsAppearingPositionSettings positionsSettings =
                    ref _mainSceneData.interferingObjectsAppearingPositionSettings;

                FillLeftBorderSidePositions(cameraBorderCornersComponent.topLeftCorner, in positionsSettings,
                    ref positionsPool);
                FillTopBorderSidePositions(cameraBorderCornersComponent.topLeftCorner, in positionsSettings,
                    ref positionsPool);
                FillBottomBorderSidePositions(cameraBorderCornersComponent.bottomRightCorner, in positionsSettings,
                    ref positionsPool);
                FillRightBorderSidePositions(cameraBorderCornersComponent.bottomRightCorner, in positionsSettings,
                    ref positionsPool);
            }
        }

        private void FillLeftBorderSidePositions(in float3 topLeftCorner
            , in InterferingObjectsAppearingPositionSettings positionSettings,
            ref List<float3> positionsPool)
        {
            float startXPoint = topLeftCorner.x - positionSettings.indentOutOfCameraBorder;

            float startYPoint = topLeftCorner.y;
            float endYPoint = topLeftCorner.y - positionSettings.lengthOfSides;

            while (startYPoint >= endYPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startYPoint -= positionSettings.distanceBetweenPositions;
            }
        }

        private void FillTopBorderSidePositions(in float3 topLeftCorner
            , in InterferingObjectsAppearingPositionSettings positionSettings,
            ref List<float3> positionsPool)
        {
            float startYPoint = topLeftCorner.y + positionSettings.indentOutOfCameraBorder;

            float startXPoint = topLeftCorner.x;
            float endXPoint = topLeftCorner.x + positionSettings.lengthOfSides;

            while (startXPoint <= endXPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startXPoint += positionSettings.distanceBetweenPositions;
            }
        }

        private void FillBottomBorderSidePositions(in float3 bottomRightCorner
            , in InterferingObjectsAppearingPositionSettings positionSettings,
            ref List<float3> positionsPool)
        {
            float startYPoint = bottomRightCorner.y - positionSettings.indentOutOfCameraBorder;

            float startXPoint = bottomRightCorner.x - positionSettings.lengthOfSides;
            float endXPoint = bottomRightCorner.x;

            while (startXPoint <= endXPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startXPoint += positionSettings.distanceBetweenPositions;
            }
        }

        private void FillRightBorderSidePositions(in float3 bottomRightCorner
            , in InterferingObjectsAppearingPositionSettings positionSettings,
            ref List<float3> positionsPool)
        {
            float startXPoint = bottomRightCorner.x + positionSettings.indentOutOfCameraBorder;

            float startYPoint = bottomRightCorner.y;
            float endYPoint = bottomRightCorner.y + positionSettings.lengthOfSides;

            while (startYPoint <= endYPoint)
            {
                positionsPool.Add(new float3(startXPoint, startYPoint, 0));
                startYPoint += positionSettings.distanceBetweenPositions;
            }
        }
    }
}