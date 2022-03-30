using ESC.Components.DirectionComponent;
using ESC.Components.PlayerTagComponent;
using Leopotam.Ecs;
using UnityEngine;

namespace ESC.Systems
{
    public sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<PlayerTagComponent, DirectionComponent> _ecsFilter = null;

        public void Run()
        {
            foreach (var entity in _ecsFilter)
            {
                ref DirectionComponent directionComponent = ref _ecsFilter.Get2(entity);
                ref Vector3 direction = ref directionComponent.direction;
                direction.x = GetDirectionX();
                direction.y = GetDirectionY();
            }
        }

        private static float GetDirectionX()
        {
            return Input.GetAxis("Horizontal");
        }
        
        private static float GetDirectionY()
        {
            return Input.GetAxis("Vertical");
        }
        
    }
}