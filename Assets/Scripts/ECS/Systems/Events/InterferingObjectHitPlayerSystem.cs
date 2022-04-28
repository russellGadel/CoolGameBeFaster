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
       
        
        public void Run()
        {
            foreach (var idx in _hitPlayerEvent)
            {
             _mainSceneServices.GameTimeService.Pause();
             
             _mainSceneServices.MainSceneEventsService.AttemptToPlayEvent.Execute();
             
             _mainSceneServices.MainSceneEventsService.SaveDataEvent.Execute();
             
             ref EcsEntity playerEntity = ref _hitPlayerEvent.GetEntity(idx);
             playerEntity.Del<InterferingObjectHitPlayerEvent>();
            }
        }
    }
}