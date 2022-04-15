using System;
using UnityEngine;

namespace ECS.Components.KinematicRigidbody2D
{
    [Serializable]
    public struct KinematicRigidbody2DComponent
    {
        public Rigidbody2D value;
    }
}