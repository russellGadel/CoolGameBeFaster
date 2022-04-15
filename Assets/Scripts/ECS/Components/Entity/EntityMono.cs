using System;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Components.Entity
{
    public class EntityMono : MonoBehaviour
    {
        public EcsEntity Entity;

        private delegate void Observers();

        private event Observers EndInitializeEvent;
        
        public void AddObserverToEndInitializeEvent(Action observer)
        {
            EndInitializeEvent += () => observer();
        }

        public void EndInitialize()
        {
            EndInitializeEvent?.Invoke();
        }
    }
}