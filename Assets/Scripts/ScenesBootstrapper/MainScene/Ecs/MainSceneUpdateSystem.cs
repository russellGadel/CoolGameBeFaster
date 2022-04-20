using CustomUI;
using ECS.Events;
using ECS.References;
using ECS.References.MainScene;
using ECS.Systems;
using ECS.Systems.Events;
using ECS.Systems.Events.ObjectsActivitySystem;
using ECS.Systems.Init;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public class MainSceneUpdateSystem : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;
        private StaticData _staticData;
        private MainSceneData _mainSceneData;
        private RuntimeData _runtimeData;
        private MainSceneServices _mainSceneServices;
        private MainSceneUIViews _mainSceneUIViews;

        
        public void Construct(ref EcsWorld world
            , ref StaticData staticData
            , ref MainSceneData mainSceneData
            , ref MainSceneUIViews mainSceneUIViews
            , ref MainSceneServices mainSceneServices
            , ref RuntimeData runtimeData)
        {
            _world = world;

            _staticData = staticData;
            _mainSceneData = mainSceneData;
            _mainSceneUIViews = mainSceneUIViews;
            _mainSceneServices = mainSceneServices;
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
                .Inject(_mainSceneUIViews)
                .Inject(_mainSceneServices)
                .Inject(_runtimeData);
        }

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _systems
                // INIT
                .Add(new InitializeEntityReferenceSystem())
                //
                .Add(new InitPositionsPoolComponentSystem())
                //
                .Add(new LoadCameraCornersSystem())
                .Add(new LoadPositionsPoolSystem())
                //
                .Add(new InitPointsEntitySystem())
                //
                .Add(new PrepareInterferingObjectsPoolSystem())
                //
                .Add(new PreparePointsSystem())
                //
                .Add(new InitObjectsSpawnAreaOnPolygonCollider2D())
                //
                //Last System at INIT
                .Add(new InitGameEntitySystem())
                // 

                //Run
                //
                .Add(new SpawnInterferingObjectsAtRandomPositionSystem())
                //
                .Add(new SpawnPointsAtRandomPositionSystem())
                //

                //Run OneFrame
                .Add(new BlockSpawnObjectsSystem())
                //
                .Add(new ActivateObjectsSystem())
                .Add(new DeactivateObjectsSystem())
                //
                .Add(new SetRandomSpeedSystem())
                //
                .Add(new PlayerGetPointSystem())
                //
                .Add(new InterferingObjectHitPlayerSystem())
                //
                
                //
                .Add(new StartGameSystem())
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