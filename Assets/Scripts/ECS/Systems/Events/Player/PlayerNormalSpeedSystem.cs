using ECS.Components.Speed;
using ECS.Events;
using ECS.References.MainScene;
using ECS.Tags.Player;
using Leopotam.Ecs;

namespace ECS.Systems.Events.Player
{
    // One Frame
    public sealed class PlayerNormalSpeedSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerNormalSpeedEvent> _event = null;
        private readonly EcsFilter<PlayerTag, SpeedComponent> _player = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Run()
        {
            foreach (var idx in _event)
            {
                ref SpeedComponent speed = ref _player.Get2(0);
                speed.value = _mainSceneData.playerSettings.normalSpeed;

                ref EcsEntity eventEntity = ref _event.GetEntity(idx);
                eventEntity.Del<PlayerNormalSpeedEvent>();
            }
        }
    }
}