using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Components.PositionsPool
{
    [Serializable]
    public struct PositionsPoolComponent
    {
        [HideInInspector] public List<float3> Positions;
    }
}