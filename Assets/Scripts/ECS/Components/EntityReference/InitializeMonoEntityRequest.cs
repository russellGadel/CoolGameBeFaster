using System;
using Leopotam.Ecs;

namespace ECS.Components.EntityReference
{
    [Serializable]
    public struct InitializeEntityMonoRequest
    {
        public MonoEntity monoEntityRef;
    }
}