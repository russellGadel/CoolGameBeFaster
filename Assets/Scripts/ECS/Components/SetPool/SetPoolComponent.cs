using System;
using UnityEngine;

namespace ECS.Components.SetPool
{
    [Serializable]
    public struct SetPoolComponent
    {
        [SerializeField] public GameObject[] pool;
    }
}