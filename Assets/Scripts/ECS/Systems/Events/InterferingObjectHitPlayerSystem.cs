using ECS.Components;
using ECS.Events;
using ECS.Tags;
using Leopotam.Ecs;
using Services.SaveData;

namespace ECS.Systems.Events
{
    public sealed class InterferingObjectHitPlayerSystem : IEcsRunSystem, ISaveData
    {
        private readonly EcsFilter<InterferingObjectHitPlayerEvent> _hitPlayerEvent = null;
        private readonly EcsFilter<GameTag, AttemptToPlayGameCounter> _game = null;

        public void Run()
        {
            foreach (var idx in _hitPlayerEvent)
            {
                ref EcsEntity gameEntity = ref _game.GetEntity(0);
                gameEntity.Replace(new GameOverComponentEvent());

                ref EcsEntity playerEntity = ref _hitPlayerEvent.GetEntity(idx);
                playerEntity.Del<InterferingObjectHitPlayerEvent>();
            }
        }
    }
}