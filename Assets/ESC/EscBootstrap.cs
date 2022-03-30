using System;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ESC
{
    public class EscBootstrap : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        public void Load()
        {
            world = new EcsWorld();
            systems = new EcsSystems(world);

            systems.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();
            
            systems.Init();
        }

        private static void AddInjections()
        {
            
        }

        private static void AddOneFrames()
        {
        }

        private static void AddSystems()
        {
            
        }


        private void Update()
        {
            systems.Run();
        }

        private void OnDestroy()
        {
            if (systems == null) return;

                DestroySystems();
            DestroyWorld();
        }

        private void DestroySystems()
        {
            systems.Destroy();
            systems = null;
        }

        private void DestroyWorld()
        {
            world.Destroy();
            world = null;
        }
    }
}