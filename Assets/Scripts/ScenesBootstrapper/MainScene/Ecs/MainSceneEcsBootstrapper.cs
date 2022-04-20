using System.Collections;
using Core.BootstrapExecutor;
using CustomUI;
using CustomUI.PlayerController;
using ECS.References;
using ECS.References.MainScene;
using ECS.Systems;
using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Zenject;

namespace ScenesBootstrapper.MainScene.Ecs
{
    public sealed class MainSceneEcsBootstrapper : MonoBehaviour, IBootstrapper
    {
        private EcsWorld _world;
        [SerializeField] private StaticData _staticData;
        [SerializeField] private MainSceneData _mainSceneData;
        [SerializeField] private MainSceneUIViews _mainSceneUIViews;
        [SerializeField] private MainSceneServices _mainSceneServices;
        private RuntimeData _runtimeData = new RuntimeData();

        [SerializeField] private MainSceneFixedUpdateSystem mainSceneFixedUpdateSystem;
        [SerializeField] private MainSceneUpdateSystem mainSceneUpdateSystem;
        private bool _ecsLoaded = false;

        public IEnumerator Execute()
        {
            _world = new EcsWorld();

            mainSceneUpdateSystem.Construct(ref _world, ref _staticData, ref _mainSceneData, ref _mainSceneUIViews
                , ref _mainSceneServices, ref _runtimeData);
            mainSceneFixedUpdateSystem.Construct(ref _world, ref _staticData, ref _mainSceneData, ref _runtimeData);

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