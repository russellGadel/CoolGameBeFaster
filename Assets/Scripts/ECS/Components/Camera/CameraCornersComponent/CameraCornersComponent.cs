using System;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Components
{
    [Serializable]
    public struct CameraCornersComponent
    {
        [HideInInspector] public float3 cameraBorderTopLeftCorner;
        [HideInInspector] public float3 cameraBorderTopRightCorner;
        [HideInInspector] public float3 cameraBorderBottomLeftCorner;
        [HideInInspector] public float3 cameraBorderBottomRightCorner;
    }
}