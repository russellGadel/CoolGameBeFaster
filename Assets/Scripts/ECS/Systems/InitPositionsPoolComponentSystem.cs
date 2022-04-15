using System.Collections.Generic;
using ECS.Components.PositionsPool;
using Leopotam.Ecs;
using Unity.Mathematics;
using UnityEngine;

namespace ECS.Systems
{
    public class InitPositionsPoolComponentSystem : IEcsInitSystem
    {
        private readonly EcsFilter<PositionsPoolComponent> _positions = null;
       
        public void Init()
        {
            Debug.Log("Init Positions pool");
            foreach (var idx in _positions)
            {
                ref PositionsPoolComponent positionsPoolComponent = ref _positions.Get1(idx);
                positionsPoolComponent.Positions = new List<float3>();
            }
        }
    }
}