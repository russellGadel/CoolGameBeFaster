using System.Collections.Generic;
using ECS.Components.EntityReference;
using JetBrains.Annotations;
using UnityEngine;

namespace ECS.Pool
{
    public sealed class EntitiesPool : MonoBehaviour
    {
        public List<MonoEntity> Elements { get; } = new List<MonoEntity>();

        public void SetCapacity(in int capacity)
        {
            Elements.Capacity = capacity;
        }

        public void AddElement(in MonoEntity entity)
        {
            Elements.Add(entity);
        }

        private int _willGetElement = 0;

        [CanBeNull]
        public MonoEntity GetNextElement()
        {
            if (Elements.Count == _willGetElement)
            {
                _willGetElement = 0;
            }

            if (Elements[_willGetElement].gameObject.activeInHierarchy == false)
            {
                Debug.Log("return element from Pool");
                return Elements[_willGetElement];
            }

            _willGetElement += 1;
            return null;
        }
    }
}