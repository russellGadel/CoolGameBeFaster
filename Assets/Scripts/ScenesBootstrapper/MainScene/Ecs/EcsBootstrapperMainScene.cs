using System.Collections;
using Core.BootstrapExecutor;
using CustomUI.PlayerController;
using ECS.Data;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public sealed class EcsBootstrapperMainScene : MonoBehaviour, IBootstrapper
    {
        private EcsWorld _world;
        [SerializeField] private StaticData _staticData;
        [SerializeField] private MainSceneData _mainSceneData;
        private RuntimeData _runtimeData = new RuntimeData();

        [SerializeField] private FixedUpdateSystemMainScene _fixedUpdateSystem;
        [SerializeField] private UpdateSystemMainScene _updateSystem;
        private bool _ecsLoaded = false;

        public IEnumerator Execute()
        {
            _world = new EcsWorld();

            _fixedUpdateSystem.Construct(ref _world, ref _staticData, ref _mainSceneData, ref _runtimeData);
            _updateSystem.Construct(ref _world, ref _staticData, ref _mainSceneData, ref _runtimeData);

            _ecsLoaded = true;

            yield return null;
        }


        private void Update()
        {
            if (_ecsLoaded == true)
            {
                _updateSystem.Run();
            }
        }

        private void FixedUpdate()
        {
            if (_ecsLoaded == true)
            {
                _fixedUpdateSystem.Run();
            }
        }

        private void OnDestroy()
        {
            DestroyWorld();
        }

        private void DestroyWorld()
        {
            if (_world == null) return;

            _world.Destroy();
            _world = null;
        }
    }
}