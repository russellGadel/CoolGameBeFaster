using System;
using UnityEngine;

namespace ECS.Components.ObjectsPoolComponent
{
    [Serializable]
    public struct ObjectsPoolComponent
    {
        public GameObject[] pool;
    }
}