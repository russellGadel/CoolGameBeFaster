using System;
using UnityEngine;

namespace ECS.Components.Movable
{
    [Serializable]
    public struct MovableComponent
    {
        [SerializeField] public Rigidbody2D rigidbody;
        [SerializeField] public float speed;
    }
}