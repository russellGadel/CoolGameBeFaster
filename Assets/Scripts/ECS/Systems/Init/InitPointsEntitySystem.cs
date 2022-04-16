using ECS.Components.PointsComponents;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitPointsEntitySystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            EcsEntity points = _world.NewEntity()
                .Replace(new CurrentPointsGotByPlayerCounterComponent())
                .Replace(new SpawnedPointsCounterComponent());
            
            
            //add components
            ref CurrentPointsGotByPlayerCounterComponent pointsGotByPlayer =
                ref points.Get<CurrentPointsGotByPlayerCounterComponent>();
            pointsGotByPlayer.Value = 0;

            ref SpawnedPointsCounterComponent spawnedPoints = ref points.Get<SpawnedPointsCounterComponent>();
            spawnedPoints.Value = 0;
        }
    }
}