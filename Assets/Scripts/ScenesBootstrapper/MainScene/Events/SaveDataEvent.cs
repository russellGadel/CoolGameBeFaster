﻿using System.Collections;
using Core.EventsLoader;
using Services.SaveData;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class SaveDataEvent : ICustomEvent
        , ICustomEventLoader
    {
        private readonly ISaveDataServiceForEvents _saveDataService;

        [Inject]
        public SaveDataEvent(ISaveDataServiceForEvents saveDataService)
        {
            _saveDataService = saveDataService;
        }

        public void Execute()
        {
            _saveDataService.Save();
        }

        public IEnumerator Load()
        {
            Execute();
            yield return null;
        }
    }
}