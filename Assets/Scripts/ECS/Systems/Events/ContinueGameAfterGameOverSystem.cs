using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags.InterferingObjects.InterferingObjectsTag;
using ECS.Tags.Points;
using Leopotam.Ecs;

namespace ECS.Systems.Events
{
    //One Frame
    public sealed class ContinueGameAfterGameOverSystem : IEcsRunSystem
    {
        private readonly EcsFilter<ContinueGameAfterGameOverEvent> _continueGameEvent = null;
        private readonly MainSceneServices _mainSceneServices = null;

        public void Run()
        {
            foreach (int idx in _continueGameEvent)
            {
                _mainSceneServices.GameTimeService.Unpause();

                PrepareInterferingObjects();
                PreparePoints();

                ref EcsEntity continueGameEvent = ref _continueGameEvent.GetEntity(idx);
                continueGameEvent.Del<ContinueGameAfterGameOverEvent>();
            }
        }

        private readonly EcsFilter<InterferingObjectsTag> _interferingObjects = null;

        private void PrepareInterferingObjects()
        {
            ref EcsEntity interferingObjectsEntity = ref _interferingObjects.GetEntity(0);
            interferingObjectsEntity.Replace(new SpawnEvent());
        }

        private readonly EcsFilter<PointsTag> _pointsTag = null;

        private void PreparePoints()
        {
            ref EcsEntity pointsEntity = ref _pointsTag.GetEntity(0);
            pointsEntity.Replace(new SpawnEvent());
        }
    }
}