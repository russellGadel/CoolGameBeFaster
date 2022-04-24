using System.Collections;
using Core.EventsLoader;
using Services.SaveData;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class LoadSavedDataEvent : ICustomEventLoader
    {
        private readonly ISaveDataService _saveDataService;

        [Inject]
        public LoadSavedDataEvent(ISaveDataService saveDataService)
        {
            _saveDataService = saveDataService;
        }

        public IEnumerator Load()
        {
            _saveDataService.Load();
            yield return null;
        }
    }
}