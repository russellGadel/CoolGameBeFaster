using ECS.Events;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.Points;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame 
    public sealed class StartGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartGameEvent> _startGameEvent = null;

        private readonly EcsFilter<InterferingObjectsTag> _interferingObjects = null;

        private readonly EcsFilter<PointsTag> _pointsTag = null;

        public void Run()
        {
            foreach (var idx in _startGameEvent)
            {
                ref EcsEntity interferingObjectsEntity = ref _interferingObjects.GetEntity(0);
                interferingObjectsEntity.Replace(new SpawnEvent());

                ref EcsEntity pointsEntity = ref _pointsTag.GetEntity(0);
                pointsEntity.Replace(new SpawnEvent());

                
                ref EcsEntity startGameEntity = ref _startGameEvent.GetEntity(idx);
                startGameEntity.Del<StartGameEvent>();
            }
        }
    }
}