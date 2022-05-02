using ECS.Components.GameObjectComponent;
using ECS.Components.SpawnPoint;
using ECS.Components.TransformComponent;
using ECS.Tags.Player;
using Leopotam.Ecs;
using UnityEngine;

namespace ECS.Systems.Init
{
    public sealed class InitPlayer : IEcsInitSystem
    {
        private readonly EcsFilter<PlayerTag, TransformComponent, GameObjectComponent> _player;
        private readonly EcsFilter<PlayerTag, SpawnPointComponent> _playerSpawnPoint;

        public void Init()
        {
            foreach (var idx in _player)
            {
                Debug.Log("SpawnPlayer at Init Position Run");
                
                ref GameObjectComponent playerObject = ref _player.Get3(0);
                DeactivatePlayer(ref playerObject);
                    
                SetForPlayerSpawnPosition();

                ActivatePlayer(ref playerObject);
            }
        }
        
        private static void DeactivatePlayer(ref GameObjectComponent playerObject)
        {
            playerObject.gameObject.SetActive(false);
        }

        private void SetForPlayerSpawnPosition()
        {
            ref TransformComponent playerTransform = ref _player.Get2(0);
            ref SpawnPointComponent spawnPoint = ref _playerSpawnPoint.Get2(0);

            playerTransform.value.position = spawnPoint.value.position;
        }

        private static void ActivatePlayer(ref GameObjectComponent playerObject)
        {
            playerObject.gameObject.SetActive(true);
        }
    }
}