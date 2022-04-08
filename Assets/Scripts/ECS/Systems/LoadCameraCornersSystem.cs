using ECS.Components.Camera.CameraComponent;
using ECS.Components.Camera.CameraCornersComponent;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Systems
{
    public class LoadCameraCornersSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<CameraComponent, CameraBorderCornersComponent>
            _ecsFilter = null;

        public void Init()
        {
            foreach (var entity in _ecsFilter)
            {
                ref CameraComponent cameraComponent = ref _ecsFilter.Get1(entity);
                ref CameraBorderCornersComponent cameraBorderCorners = ref _ecsFilter.Get2(entity);

                ref Camera camera = ref cameraComponent.camera;

                ref float3 topRightCorner = ref cameraBorderCorners.topRightCorner;
                ref float3 bottomRightCorner = ref cameraBorderCorners.bottomRightCorner;
                ref float3 topLeftCorner = ref cameraBorderCorners.topLeftCorner;
                ref float3 bottomLeftCorner = ref cameraBorderCorners.bottomLeftCorner;

                topRightCorner = TopRightCorner(ref camera);
                bottomRightCorner = BottomRightCorner(topRightCorner, ref camera);

                Rect pixelRect = camera.pixelRect;
                float orthographicSize = camera.orthographicSize;
                float coefficientOnXAngle =
                    ((pixelRect.width / pixelRect.height) * orthographicSize);

                topLeftCorner = TopLeftCorner(topRightCorner, coefficientOnXAngle);
                bottomLeftCorner = BottomLeftCorner(topLeftCorner, orthographicSize);
            }
        }
        
        private static Vector3 TopRightCorner(ref Camera camera)
        {
            return camera.ViewportToWorldPoint(new float3(1, 1, camera.nearClipPlane));
        }

        private static float3 BottomRightCorner(float3 topRightCorner, ref Camera camera)
        {
            return new float3(topRightCorner.x,
                topRightCorner.y - (camera.orthographicSize * 2), 0);
        }
        private static Vector3 TopLeftCorner(float3 topRightCorner, float coefficientOnXAngle)
        {
            return new Vector3(topRightCorner.x - (coefficientOnXAngle * 2.0f),
                topRightCorner.y, 0);
        }
        private static Vector3 BottomLeftCorner(float3 topLeftCorner, float orthographicSize)
        {
            return new Vector3(topLeftCorner.x,
                topLeftCorner.y - (orthographicSize * 2), 0);
        }
    }
}