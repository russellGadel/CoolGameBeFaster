using ECS.Components.CameraComponent.CameraComponent;
using ECS.Components.CameraComponent.CameraCornersComponent;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Systems.Init
{
    public sealed class InitCameraCornersSystem : IEcsInitSystem
    {
        private readonly EcsFilter<CameraComponent, CameraBorderCornersComponent> _ecsFilter = null;

        public void Init()
        {
            foreach (int entity in _ecsFilter)
            {
                ref CameraComponent cameraComponent = ref _ecsFilter.Get1(entity);
                ref CameraBorderCornersComponent cameraBorderCorners = ref _ecsFilter.Get2(entity);

                ref Camera camera = ref cameraComponent.camera;

                ref float3 topRightCorner = ref cameraBorderCorners.topRightCorner;
                ref float3 bottomRightCorner = ref cameraBorderCorners.bottomRightCorner;
                ref float3 topLeftCorner = ref cameraBorderCorners.topLeftCorner;
                ref float3 bottomLeftCorner = ref cameraBorderCorners.bottomLeftCorner;

                topRightCorner = GetTopRightCorner(in camera);
                bottomRightCorner = GetBottomRightCorner(in topRightCorner, in camera);

                Rect pixelRect = camera.pixelRect;
                float orthographicSize = camera.orthographicSize;
                float coefficientOnXAngle = (pixelRect.width / pixelRect.height) * orthographicSize;

                topLeftCorner = GetTopLeftCorner(in topRightCorner, in coefficientOnXAngle);
                bottomLeftCorner = GetBottomLeftCorner(in topLeftCorner, in orthographicSize);
            }
        }

        private Vector3 GetTopRightCorner(in Camera camera)
        {
            return camera.ViewportToWorldPoint(new float3(1, 1, camera.nearClipPlane));
        }

        private float3 GetBottomRightCorner(in float3 topRightCorner, in Camera camera)
        {
            return new float3(topRightCorner.x, topRightCorner.y - (camera.orthographicSize * 2), 0);
        }

        private float3 GetTopLeftCorner(in float3 topRightCorner, in float coefficientOnXAngle)
        {
            return new float3(topRightCorner.x - (coefficientOnXAngle * 2.0f), topRightCorner.y, 0);
        }

        private float3 GetBottomLeftCorner(in float3 topLeftCorner, in float orthographicSize)
        {
            return new float3(topLeftCorner.x, topLeftCorner.y - (orthographicSize * 2), 0);
        }
    }
}