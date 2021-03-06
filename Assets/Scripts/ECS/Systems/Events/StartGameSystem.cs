using ECS.Components;
using ECS.Components.PointsComponents;
using ECS.Components.TransformComponent;
using ECS.Events;
using ECS.Events.SpawnPlayer;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.Player;
using ECS.Tags.Points;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame 
    public sealed class StartGameSystem : IEcsRunSystem
    {
        private readonly EcsFilter<StartGameEcsEvent> _startGameEvent = null;
        private readonly MainSceneServices _mainSceneServices = null;
        private readonly EcsFilter<GameTag, AttemptToPlayGameCounter> _game = null;

        private readonly int _firstAttempt = 1;

        public void Run()
        {
            foreach (int idx in _startGameEvent)
            {
                SpawnPlayerAtInitPosition();
                PreparePoints();
                PrepareInterferingObjects();
                
                ref AttemptToPlayGameCounter attemptCounter = ref _game.Get2(0);
                attemptCounter.Value = _firstAttempt;

                _mainSceneServices.GameTimeService.Unpause();
                
                ref EcsEntity startGameEntity = ref _startGameEvent.GetEntity(idx);
                startGameEntity.Del<StartGameEcsEvent>();
            }
        }

        private readonly EcsFilter<PlayerTag, TransformComponent> _player = null;

        private void SpawnPlayerAtInitPosition()
        {
            ref EcsEntity playerEntity = ref _player.GetEntity(0);
            playerEntity.Replace(new SpawnPlayerAtInitPositionEvent());
        }


        private readonly EcsFilter<PointsTag
            , CurrentPointsGotByPlayerCounterComponent
            , SpawnedPointsCounterComponent> _pointsTag = null;

        private readonly MainSceneUIViews _mainSceneUIViews = null;
        
        private void PreparePoints()
        {
            ref EcsEntity pointsEntity = ref _pointsTag.GetEntity(0);

            ref CurrentPointsGotByPlayerCounterComponent pointsCounter = ref _pointsTag.Get2(0);
            pointsCounter.Value = 0;
            _mainSceneUIViews.PlayerPointsViewsGroup.UpdatePoints(in pointsCounter.Value);

            ref SpawnedPointsCounterComponent spawnedPointsCounter = ref _pointsTag.Get3(0);
            spawnedPointsCounter.Value = 0;
            
            pointsEntity.Replace(new SpawnEvent());
        }

        
        private readonly EcsFilter<InterferingObjectsTag> _interferingObjects = null;
        
        private void PrepareInterferingObjects()
        {
            ref EcsEntity interferingObjectsEntity = ref _interferingObjects.GetEntity(0);
            interferingObjectsEntity.Replace(new SpawnEvent());
        }
    }
}