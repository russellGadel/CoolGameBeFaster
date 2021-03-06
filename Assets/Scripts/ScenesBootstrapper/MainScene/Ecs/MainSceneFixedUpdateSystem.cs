using CustomUI.PlayerController;
using ECS.References;
using ECS.References.MainScene;
using ECS.Systems;
using ECS.Systems.Events.Player;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public class MainSceneFixedUpdateSystem : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _system;

        private StaticData _staticData;
        private MainSceneData _mainSceneData;
        private RuntimeData _runtimeData;

        public void Construct(in EcsWorld world
            , in StaticData staticData
            , in MainSceneData mainSceneData
            , in RuntimeData runtimeData)
        {
            _world = world;

            _staticData = staticData;
            _mainSceneData = mainSceneData;
            _runtimeData = runtimeData;

            _system = new EcsSystems(_world);
            _system.ConvertScene();

            AddInjections();
            AddOneFrames();
            AddSystems();

            _system.Init();
        }

        public void Run()
        {
            _system.Run();
        }


        [Inject] private IPlayerControllerPresenter _playerController;

        private void AddInjections()
        {
            _system
                .Inject(_playerController)
                .Inject(_staticData)
                .Inject(_mainSceneData)
                .Inject(_runtimeData);
        }

        private void AddOneFrames()
        {
        }

        private void AddSystems()
        {
            _system
                //Run
                .Add(new PlayerInputSystem())
                .Add(new PlayerMovementSystem())
                //

                //
                .Add(new LookAtPlayerSystem()) // One Frame
                .Add(new KinematicRigidbody2DMovementSystem())
                ;
        }

        private void OnDestroy()
        {
            DestroySystems();
        }

        private void DestroySystems()
        {
            if (_system == null) return;
            _system.Destroy();
            _system = null;
        }
    }
}