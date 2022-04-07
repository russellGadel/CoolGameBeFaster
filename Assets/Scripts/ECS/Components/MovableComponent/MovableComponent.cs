using System;
using UnityEngine;

namespace ECS.Components.MovableComponent
{
    [Serializable]
    public struct MovableComponent
    {
        public Rigidbody2D rigidbody;
        public float speed;
    }
}