using ECS.Components.InterferingObjectsTags.InterferingObjectsAppearingPositionsGridTag;
using ECS.Components.PositionsPool;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public class SpawnInterferingObjectsAtRandomPositions //: IEcsRunSystem
    {
        private readonly EcsWorld _world = null;

        private readonly EcsFilter<InterferingObjectsAppearingPositionsGridTag, PositionsPoolComponent>
            _spawnPositionsGrid = null;

        
       /* public void Run()
        {
            foreach (var entity in _ecsFilter)
            {
                ref TransformComponent transformComponent = ref _ecsFilter.Get2(entity);
                ref MovableComponent movableComponent = ref _ecsFilter.Get3(entity);
                ref DirectionComponent directionComponent = ref _ecsFilter.Get4(entity);

                ref Transform transform = ref transformComponent.transform;

                ref Rigidbody2D rigidbody = ref movableComponent.rigidbody;
                ref float speed = ref movableComponent.speed;

                ref Vector3 direction = ref directionComponent.direction;

                 

                rigidbody.AddForce(direction * speed);
            }
        }*/
    }
}