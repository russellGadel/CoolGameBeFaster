using CustomUI.PlayerController;
using ECS.Data;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public class FixedUpdateSystemMainScene : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _system;

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