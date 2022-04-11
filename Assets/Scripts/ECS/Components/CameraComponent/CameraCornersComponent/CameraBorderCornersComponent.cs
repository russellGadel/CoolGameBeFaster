using System;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Components.CameraComponent.CameraCornersComponent
{
    [Serializable]
    public struct CameraBorderCornersComponent
    {
        [HideInInspector] public float3 topLeftCorner;
        [HideInInspector] public float3 topRightCorner;
        [HideInInspector] public float3 bottomLeftCorner;
        [HideInInspector] public float3 bottomRightCorner;
    }
}