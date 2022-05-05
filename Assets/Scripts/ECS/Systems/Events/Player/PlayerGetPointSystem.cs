using ECS.Components.PointsComponents;
using ECS.Events;
using ECS.References.MainScene;
using Leopotam.Ecs;

namespace ECS.Systems.Events.Player
{
    public sealed class PlayerGetPointSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerGetPointEvent> _playerGetPointEvents = null;
        private readonly EcsFilter<CurrentPointsGotByPlayerCounterComponent> _points;
        private readonly MainSceneUIViews _mainSceneUIViews = null;

        public void Run()
        {
            foreach (var idx in _playerGetPointEvents)
            {
                ref CurrentPointsGotByPlayerCounterComponent gotPoints = ref _points.Get1(0);
                gotPoints.Value += 1;
                _mainSceneUIViews.PlayerPointsViewsGroup.UpdatePoints(gotPoints.Value);


                ref EcsEntity entity = ref _playerGetPointEvents.GetEntity(idx);
                entity.Del<PlayerGetPointEvent>();
            }
        }
    }
}