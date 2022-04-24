using System;
using ECS.Events;
using ECS.References.MainScene;
using Leopotam.Ecs;
using Services.SaveData;

namespace ECS.Systems.Events
{
    public class InterferingObjectHitPlayerSystem : IEcsRunSystem, ISaveData
    {
        private readonly EcsFilter<InterferingObjectHitPlayerEvent> _hitPlayerEvent = null;
        private readonly MainSceneServices _mainSceneServices;
        private readonly MainSceneUIViews _mainSceneUIViews;
        
        public void Run()
        {
            foreach (var idx in _hitPlayerEvent)
            {
             _mainSceneServices.GameTimeService.Pause();
             _mainSceneUIViews.AttemptToPlayView.Open();
             
             _mainSceneServices.MainSceneEventsService.SaveDataEvent.Execute();
             
             ref EcsEntity playerEntity = ref _hitPlayerEvent.GetEntity(idx);
             playerEntity.Del<InterferingObjectHitPlayerEvent>();
            }
        }
    }
}