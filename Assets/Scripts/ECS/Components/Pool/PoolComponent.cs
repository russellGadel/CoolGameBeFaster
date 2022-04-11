using System;
using UnityEngine;

namespace ECS.Components.Pool
{
    [Serializable]
    public struct PoolComponent
    {
        public Transform transform;
        public GameObject prefab;
        [HideInInspector] public GameObject[] pool;
        public int elementsAmount;
    }
}