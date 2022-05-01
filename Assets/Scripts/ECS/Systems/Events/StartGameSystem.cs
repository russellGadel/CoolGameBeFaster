using ECS.Components.PointsComponents;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.Points;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame 
    public sealed class StartGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartGameEvent> _startGameEvent = null;
        private readonly MainSceneServices _mainSceneServices;

        public void Run()
        {
            foreach (var idx in _startGameEvent)
            {
                PrepareInterferingObjects();
                PreparePoints();

                _mainSceneServices.GameTimeService.Unpause();

                ref EcsEntity startGameEntity = ref _startGameEvent.GetEntity(idx);
                startGameEntity.Del<StartGameEvent>();
            }
        }

        private readonly EcsFilter<InterferingObjectsTag> _interferingObjects = null;

        private void PrepareInterferingObjects()
        {
            ref EcsEntity interferingObjectsEntity = ref _interferingObjects.GetEntity(0);
            interferingObjectsEntity.Replace(new SpawnEvent());
        }

        private readonly EcsFilter<PointsTag, CurrentPointsGotByPlayerCounterComponent> _pointsTag = null;
        private readonly MainSceneUIViews _mainSceneUIViews = null;

        private void PreparePoints()
        {
            ref EcsEntity pointsEntity = ref _pointsTag.GetEntity(0);

            ref CurrentPointsGotByPlayerCounterComponent pointsCounter = ref _pointsTag.Get2(0);
            pointsCounter.Value = 0;
            _mainSceneUIViews.PlayerPointsViewsGroup.UpdatePoints(pointsCounter.Value);

            pointsEntity.Replace(new SpawnEvent());
        }
    }
}