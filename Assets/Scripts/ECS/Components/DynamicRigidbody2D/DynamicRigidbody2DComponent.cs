using System;
using UnityEngine;

namespace ECS.Components.DynamicRigidbody2D
{
    [Serializable]
    public struct DynamicRigidbody2DComponent
    {
        public Rigidbody2D value;
    }
}