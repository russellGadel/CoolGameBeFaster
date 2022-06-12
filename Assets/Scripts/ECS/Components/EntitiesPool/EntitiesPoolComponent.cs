using System;

namespace ECS.Components.EntitiesPool
{
    [Serializable]
    public struct EntitiesPoolComponent
    {
        public Pool.EntitiesPool pool;
    }
}