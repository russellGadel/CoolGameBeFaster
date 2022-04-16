using System;

namespace ECS.Components.SpeedRange
{
    [Serializable]
    public struct SpeedRangeComponent
    {
        public float MinSpeed;
        public float MaxSpeed;
    }
}