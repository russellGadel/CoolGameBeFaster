using System.Collections;
using Core.BootstrapExecutor;
using ECS.References;
using ECS.References.MainScene;
using Leopotam.Ecs;
using UnityEngine;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public sealed class MainSceneEcsBootstrapper : MonoBehaviour, IBootstrapper
    {
        private EcsWorld _world;
        [SerializeField] private StaticData _staticData;
        [SerializeField] private MainSceneData _mainSceneData;
        [SerializeField] private MainSceneUIViews _mainSceneUIViews;
        [SerializeField] private MainSceneServices _mainSceneServices;
        private readonly RuntimeData _runtimeData = new RuntimeData();

        [SerializeField] private MainSceneFixedUpdateSystem mainSceneFixedUpdateSystem;
        [SerializeField] private MainSceneUpdateSystem mainSceneUpdateSystem;
        private bool _ecsLoaded = false;

        public IEnumerator Execute()
        {
            _world = new EcsWorld();

            mainSceneUpdateSystem.Construct(_world, _staticData, _mainSceneData, _mainSceneUIViews, _mainSceneServices,
                _runtimeData);

            mainSceneFixedUpdateSystem.Construct(_world, _staticData, _mainSceneData, _runtimeData);

            _ecsLoaded = true;

            yield return null;
        }


        private void Update()
        {
            if (_ecsLoaded == true)
            {
                mainSceneUpdateSystem.Run();
            }
        }

        private void FixedUpdate()
        {
            if (_ecsLoaded == true)
            {
                mainSceneFixedUpdateSystem.Run();
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