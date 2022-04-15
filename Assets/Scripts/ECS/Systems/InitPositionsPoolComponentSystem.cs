using System.Collections.Generic;
using ECS.Components.PositionsPool;
using Leopotam.Ecs;
using Unity.Mathematics;

namespace ECS.Systems
{
    public class InitPositionsPoolComponentSystem : IEcsInitSystem
    {
        private readonly EcsFilter<PositionsPoolComponent> _positions = null;
       
        public void Init()
        {
            foreach (var idx in _positions)
            {
                ref PositionsPoolComponent positionsPoolComponent = ref _positions.Get1(idx);
                positionsPoolComponent.Positions = new List<float3>();
            }
        }
    }
}