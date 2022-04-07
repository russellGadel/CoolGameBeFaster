using System.Collections;
using Core.BootstrapExecutor;
using CustomUI.PlayerController;
using ESC.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene
{
    public sealed class EscBootstrapperMainScene : MonoBehaviour, IBootstrapper
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private bool _escLoaded = false;

        public IEnumerator Execute()
        {
            Debug.Log("Execute ESC");
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();

            _escLoaded = true;

            yield return null;
        }


        [Inject] private IPlayerControllerPresenter _playerController;

        private void AddInjections()
        {
            _systems.Inject(_playerController);
        }

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _systems
                    // init
                .Add(new LoadRandomMapSystem())
                    
                    //Run
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                ;
        }


        private void Update()
        {
            if (_escLoaded == true)
            {
                _systems.Run();
            }
        }

        private void OnDestroy()
        {
            if (_systems == null) return;

            DestroySystems();
            DestroyWorld();
        }

        private void DestroySystems()
        {
            _systems.Destroy();
            _systems = null;
        }

        private void DestroyWorld()
        {
            _world.Destroy();
            _world = null;
        }
    }
}