using ECS.Components;
using ECS.Components.PointsComponents;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.Points;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    // One Frame Event
    public sealed class GameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverComponentEvent> _gameOverEvent = null;
        private readonly EcsFilter<GameTag, AttemptToPlayGameCounter> _game = null;

        private readonly MainSceneServices _mainSceneServices = null;
        private readonly MainSceneData _mainSceneData = null;


        public void Run()
        {
            foreach (int idx in _gameOverEvent)
            {
                ref EcsEntity gameOverEvent = ref _gameOverEvent.GetEntity(idx);
                gameOverEvent.Del<GameOverComponentEvent>();
                
                _mainSceneServices
                    .CustomInvokerService
                    .CustomInvoke(() => DelayGameOver(in idx),
                        _mainSceneData.gamePlaySettings.timeDelayBeforeGameOverPlayer);
            }
        }

        private void DelayGameOver(in int idx)
        {
            _mainSceneServices.GameTimeService.Pause();

            ref AttemptToPlayGameCounter attemptCounter = ref _game.Get2(0);
            attemptCounter.Value += 1;

            OffInterferingObjects();
            OffPoints();

            ref CurrentPointsGotByPlayerCounterComponent currentPoints = ref _points.Get2(0);
            ref MaxPointsAmountGotByPlayer maxPoints = ref _points.Get3(0);

            SetMaxPoints(in currentPoints.Value, ref maxPoints.Value);

            if (IsCanTakeAttemptToPlay(in attemptCounter))
            {
                ExecuteAttemptToPlayEvent(in currentPoints.Value, in maxPoints.Value);
            }
            else
            {
                ExecuteGameOverEvent(in currentPoints.Value, in maxPoints.Value);
            }

            _mainSceneServices.MainSceneEventsService.SaveDataEvent.Execute();
        }


        private void SetMaxPoints(in double currentPoints, ref double maxPoints)
        {
            if (currentPoints > maxPoints)
            {
                maxPoints = currentPoints;
            }
        }

        
        private bool IsCanTakeAttemptToPlay(in AttemptToPlayGameCounter attemptCounter)
        {
            return attemptCounter.Value == _mainSceneData.gamePlaySettings.amountOfAttemptToPlayGame;
        }
        

        private readonly EcsFilter<PointsTag
            , CurrentPointsGotByPlayerCounterComponent
            , MaxPointsAmountGotByPlayer> _points = null;

        private void ExecuteAttemptToPlayEvent(in double currentPoints, in double maxPoints)
        {
            _mainSceneServices
                .MainSceneEventsService
                .AttemptToPlayWindowEvents.Execute(currentPoints, maxPoints);
        }

        private void ExecuteGameOverEvent(in double currentPoints, in double maxPoints)
        {
            _mainSceneServices
                .MainSceneEventsService
                .GameOverWindowEvents
                .Execute(currentPoints, maxPoints);
        }


        private readonly EcsFilter<InterferingObjectsTag> _interferingObjectsMain = null;

        private void OffInterferingObjects()
        {
            ref EcsEntity interferingObjectsEntity = ref _interferingObjectsMain.GetEntity(0);
            interferingObjectsEntity.Del<SpawnEvent>();
            interferingObjectsEntity.Replace(new DeactivateInterferingObjectsEvent());
        }


        private readonly EcsFilter<PointsTag> _pointsTag = null;

        private void OffPoints()
        {
            ref EcsEntity pointsEntity = ref _pointsTag.GetEntity(0);
            pointsEntity.Del<SpawnEvent>();
            pointsEntity.Replace(new DeactivateActivePointsEvent());
        }
    }
}