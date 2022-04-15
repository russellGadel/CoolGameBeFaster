using ECS.Components.GameStatus;
using ECS.Events;
using Leopotam.Ecs;

namespace ECS.Systems
{
    public sealed class InitGameEntitySystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            EcsEntity game = _world.NewEntity()
                .Replace(new GameStatusComponent())
                .Replace(new StartGameEvent());
        }
    }
}