using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Components.PositionsPool
{
    public struct PositionsPoolComponent
    {
        [HideInInspector] public List<float3> Positions;
    }
}