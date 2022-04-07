using System;
using UnityEngine;

namespace ESC.Components.MovableComponent
{
    [Serializable]
    public struct MovableComponent
    {
        public Rigidbody2D rigidbody;
        public float speed;
    }
}