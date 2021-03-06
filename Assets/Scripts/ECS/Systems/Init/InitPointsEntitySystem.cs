using System;
using ECS.Components.PointsComponents;
using ECS.References.MainScene;
using ECS.Tags.Points;
using Leopotam.Ecs;
using Services.SaveData;

namespace ECS.Systems.Init
{
    public sealed class InitPointsEntitySystem : IEcsInitSystem
        , ISavedDataReader
        , ISaveData
        , IDisposable
    {
        private readonly EcsWorld _world = null;
        private readonly MainSceneServices _mainSceneServices = null;

        public void Init()
        {
            EcsEntity points = _world.NewEntity()
                .Replace(new PointsTag())
                .Replace(new CurrentPointsGotByPlayerCounterComponent())
                .Replace(new SpawnedPointsCounterComponent())
                .Replace(new MaxPointsAmountGotByPlayer());


            //add components
            ref CurrentPointsGotByPlayerCounterComponent pointsGotByPlayer =
                ref points.Get<CurrentPointsGotByPlayerCounterComponent>();
            pointsGotByPlayer.Value = 0;

            ref SpawnedPointsCounterComponent spawnedPoints = ref points.Get<SpawnedPointsCounterComponent>();
            spawnedPoints.Value = 0;

            ref MaxPointsAmountGotByPlayer maxPointsAmount = ref points.Get<MaxPointsAmountGotByPlayer>();

            LoadSavedData(ref maxPointsAmount);

            _mainSceneServices.SaveDataService.SubscribeToSaveEvent(Save);
        }

        void IDisposable.Dispose()
        {
            _mainSceneServices.SaveDataService.UnsubscribeFromSaveEvent(Save);
        }

        private void LoadSavedData(ref MaxPointsAmountGotByPlayer maxPointsAmount)
        {
            maxPointsAmount.Value = _mainSceneServices.SaveDataService.GetData().maxPointsAmountGotByPlayer;
        }


        private readonly EcsFilter<PointsTag, MaxPointsAmountGotByPlayer> _points = null;

        private void Save()
        {
            ref SaveData saveData = ref _mainSceneServices.SaveDataService.GetData();

            foreach (int idx in _points)
            {
                ref MaxPointsAmountGotByPlayer maxPointsAmount = ref _points.Get2(idx);
                saveData.maxPointsAmountGotByPlayer = maxPointsAmount.Value;
            }
        }
    }
}