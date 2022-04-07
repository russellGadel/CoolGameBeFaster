using CustomUI.PlayerController;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public class UpdateSystemMainScene : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public void Construct(ref EcsWorld world)
        {
            _world = world;

            _systems = new EcsSystems(_world);
            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();
        }

        public void Run()
        {
            _systems.Run();
        }
        
        
        private void AddInjections()
        {
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
                ;
        }

        private void OnDestroy()
        {
            DestroySystems();
        }

        private void DestroySystems()
        {
            if (_systems == null) return;
            _systems.Destroy();
            _systems = null;
        }
    }
}