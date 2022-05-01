using ECS.Components;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.Points;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    public class GameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<GameOverComponentEvent> _gameOverEvent = null;
        private readonly EcsFilter<GameTag, AttemptToPlayGameCounter> _game = null;

        private readonly MainSceneServices _mainSceneServices = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (var idx in _gameOverEvent)
            {
                _mainSceneServices.GameTimeService.Pause();

                ref AttemptToPlayGameCounter attemptCounter = ref _game.Get2(0);
                attemptCounter.Value += 1;

                OffInterferingObjects();
                OffPoints();


                if (IsCanTakeAttemptToPlay(ref attemptCounter))
                {
                    _mainSceneServices.MainSceneEventsService.AttemptToPlayEvent.Execute();
                }
                else
                {
                    _mainSceneServices.MainSceneEventsService.GameOverEvent.Execute();
                }

                _mainSceneServices.MainSceneEventsService.SaveDataEvent.Execute();

                ref EcsEntity gameOverEvent = ref _gameOverEvent.GetEntity(idx);
                gameOverEvent.Del<GameOverComponentEvent>();
            }
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