using ECS.Data;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public class UpdateSystemMainScene : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private StaticData _staticData;
        private MainSceneData _mainSceneData;
        private RuntimeData _runtimeData;

        public void Construct(ref EcsWorld world, ref StaticData staticData, ref MainSceneData mainSceneData,
            ref RuntimeData runtimeData)
        {
            _world = world;

            _staticData = staticData;
            _mainSceneData = mainSceneData;
            _runtimeData = runtimeData;

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
            _systems
                .Inject(_staticData)
                .Inject(_mainSceneData)
                .Inject(_runtimeData);
        }

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _systems
                // init
                .Add(new FillPoolsWithPrefabsSystem())
                //
                .Add(new LoadRandomMapSystem())
                //
                .Add(new LoadCameraCornersSystem())
                .Add(new LoadPositionsPoolSystem())
                //
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