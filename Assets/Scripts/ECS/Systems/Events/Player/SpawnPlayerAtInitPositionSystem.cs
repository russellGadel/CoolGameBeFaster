using ECS.Components.GameObjectComponent;
using ECS.Components.SpawnPoint;
using ECS.Components.TransformComponent;
using ECS.Events.SpawnPlayer;
using ECS.Tags.Player;
using Leopotam.Ecs;

namespace ECS.Systems.Events.Player
{
    // One frame
    public sealed class SpawnPlayerAtInitPositionSystem : IEcsRunSystem
    {
        private readonly EcsFilter<SpawnPlayerAtInitPositionEvent> _spawnPlayerEvent = null;
        private readonly EcsFilter<PlayerTag, TransformComponent, GameObjectComponent> _player = null;
        private readonly EcsFilter<PlayerTag, SpawnPointComponent> _playerSpawnPoint = null;

        public void Run()
        {
            foreach (int idx in _spawnPlayerEvent)
            {
                ref GameObjectComponent playerObject = ref _player.Get3(0);
                DeactivatePlayer(in playerObject);

                SetForPlayerSpawnPosition();

                ActivatePlayer(in playerObject);

                ref EcsEntity spawnPlayerEventEntity = ref _spawnPlayerEvent.GetEntity(idx);
                spawnPlayerEventEntity.Del<SpawnPlayerAtInitPositionEvent>();
            }
        }


        private void DeactivatePlayer(in GameObjectComponent playerObject)
        {
            playerObject.gameObject.SetActive(false);
        }

        private void SetForPlayerSpawnPosition()
        {
            ref TransformComponent playerTransform = ref _player.Get2(0);
            ref SpawnPointComponent spawnPoint = ref _playerSpawnPoint.Get2(0);

            playerTransform.value.position = spawnPoint.value.position;
        }

        private void ActivatePlayer(in GameObjectComponent playerObject)
        {
            playerObject.gameObject.SetActive(true);
        }
    }
}