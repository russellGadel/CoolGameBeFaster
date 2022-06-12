using ECS.Components;
using ECS.Components.GameStatus;
using ECS.Components.LevelDifficulty;
using ECS.Tags;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitGameEntitySystem : IEcsInitSystem
    {
        private readonly EcsWorld _world = null;

        public void Init()
        {
            AttemptToPlayGameCounter attemptToPlayGameCounter = new AttemptToPlayGameCounter()
            {
                Value = 1
            };


            EcsEntity game = _world.NewEntity()
                .Replace(new GameTag())
                .Replace(new GameStatusComponent())
                .Replace(attemptToPlayGameCounter);
        }
    }
}