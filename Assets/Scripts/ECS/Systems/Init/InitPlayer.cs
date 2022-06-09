using ECS.Components.Speed;
using ECS.References.MainScene;
using ECS.Tags.Player;
using Leopotam.Ecs;

namespace ECS.Systems.Init
{
    public sealed class InitPlayer : IEcsInitSystem
    {
        private readonly EcsFilter<PlayerTag, SpeedComponent> _player = null;
        private readonly MainSceneData _mainSceneData = null;

        public void Init()
        {
            foreach (int idx in _player)
            {
                ref SpeedComponent speed = ref _player.Get2(idx);
                speed.value = _mainSceneData.playerSettings.normalSpeed;
            }
        }
    }
}