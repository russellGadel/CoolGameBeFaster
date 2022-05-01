using ECS.Components.PointsComponents;
using ECS.References.MainScene;
using ECS.Tags.Points;
using Leopotam.Ecs;
using Services.SaveData;

namespace ECS.Systems.Init
{
    public sealed class InitPointsEntitySystem : IEcsInitSystem, ISavedDataReader, ISaveData
    {
        private readonly EcsWorld _world = null;
        private readonly MainSceneServices _mainSceneServices;

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

            Load(ref maxPointsAmount);

            _mainSceneServices.SaveDataService.AddSaveEventObservers(Save);
        }

        private void Load(ref MaxPointsAmountGotByPlayer maxPointsAmount)
        {
            maxPointsAmount.Value = _mainSceneServices.SaveDataService.GetData().maxPointsAmountGotByPlayer;
        }


        private readonly EcsFilter<PointsTag, MaxPointsAmountGotByPlayer> _points;

        private void Save()
        {
            ref SaveData saveData = ref _mainSceneServices.SaveDataService.GetData();

            foreach (var idx in _points)
            {
                ref MaxPointsAmountGotByPlayer maxPointsAmount = ref _points.Get2(idx);
                saveData.maxPointsAmountGotByPlayer = maxPointsAmount.Value;
            }
        }
    }
}