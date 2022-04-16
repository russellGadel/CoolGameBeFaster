using System;
using Leopotam.Ecs;

namespace ECS.Components.EntityReference
{
    [Serializable]
    public struct InitializeEntityRequest
    {
        public EntityReferenceComponent entityRef;
    }
}