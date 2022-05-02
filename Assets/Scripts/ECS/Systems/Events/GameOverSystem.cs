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
    public sealed class GameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverComponentEvent> _gameOverEvent = null;
        private readonly EcsFilter<GameTag, AttemptToPlayGameCounter> _game = null;

        private readonly MainSceneServices _mainSceneServices = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (var idx in _gameOverEvent)
            {
                ref EcsEntity gameOverEvent = ref _gameOverEvent.GetEntity(idx);
                gameOverEvent.Del<GameOverComponentEvent>();

                float delayTime = _mainSceneData.gameSettings.timeDelayBeforeGameOverPlayer;

                _mainSceneServices
                    .CustomInvokerService
                    .CustomInvoke(() => DelayGameOver(idx), delayTime);
            }
        }

        private void DelayGameOver(int idx)
        {
            _mainSceneServices.GameTimeService.Pause();

            ref AttemptToPlayGameCounter attemptCounter = ref _game.Get2(0);
            attemptCounter.Value += 1;

            OffInterferingObjects();
            OffPoints();

            ref CurrentPointsGotByPlayerCounterComponent currentPoints = ref _points.Get2(0);
            ref MaxPointsAmountGotByPlayer maxPoints = ref _points.Get3(0);

            SetMaxPoints(ref currentPoints.Value, ref maxPoints.Value);

            if (IsCanTakeAttemptToPlay(ref attemptCounter))
            {
                ExecuteAttemptToPlayEvent(ref currentPoints.Value, ref maxPoints.Value);
            }
            else
            {
                ExecuteGameOverEvent(ref currentPoints, ref maxPoints);
            }

            _mainSceneServices.MainSceneEventsService.SaveDataEvent.Execute();
        }


        private void SetMaxPoints(ref double currentPoints, ref double maxPoints)
        {
            if (currentPoints > maxPoints)
            {
                maxPoints = currentPoints;
            }
        }


        private readonly EcsFilter<PointsTag
            , CurrentPointsGotByPlayerCounterComponent
            , MaxPointsAmountGotByPlayer> _points = null;

        private void ExecuteAttemptToPlayEvent(ref double currentPoints, ref double maxPoints)
        {
            _mainSceneServices
                .MainSceneEventsService
                .AttemptToPlayEvent.Execute(currentPoints, maxPoints);
        }

        private void ExecuteGameOverEvent(ref CurrentPointsGotByPlayerCounterComponent currentPoints,
            ref MaxPointsAmountGotByPlayer maxPoints)
        {
            _mainSceneServices
                .MainSceneEventsService
                .GameOverEvent
                .Execute(currentPoints.Value, maxPoints.Value);
        }

        private bool IsCanTakeAttemptToPlay(ref AttemptToPlayGameCounter attemptCounter)
        {
            return attemptCounter.Value == _mainSceneData.gameSettings.amountOfAttemptToPlayGame;
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