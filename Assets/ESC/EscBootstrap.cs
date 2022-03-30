using System;
using ESC.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ESC
{
    public sealed class EscBootstrap : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        public void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _systems.Init();
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
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                ;
        }


        private void Update()
        {
            _systems.Run();
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