using ECS.Events;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame 
    public class StartGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartGameEvent> _startGameEvent = null;

        private readonly EcsFilter<InterferingObjectsTag> _interferingObjects = null;
            
        public void Run()
        {
            foreach (var idx in _startGameEvent)
            {
                ref EcsEntity interferingObjectsEntity = ref _interferingObjects.GetEntity(0);
                interferingObjectsEntity.Get<SpawnEvent>();


                ref EcsEntity startGameEntity = ref _startGameEvent.GetEntity(idx);
                startGameEntity.Del<StartGameEvent>();
            }
        }
    }
}