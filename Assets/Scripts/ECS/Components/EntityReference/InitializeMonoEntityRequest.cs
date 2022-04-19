using System;

namespace ECS.Components.EntityReference
{
    [Serializable]
    public struct InitializeEntityMonoRequest
    {
        public MonoEntity monoEntityRef;
    }
}