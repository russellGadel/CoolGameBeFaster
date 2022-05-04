using System.Collections;
using Core.EventsLoader;
using Services.SaveData;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class LoadSavedDataEvent : ICustomEventLoader
    {
        private readonly ISaveDataServiceForEvents _saveDataService;

        [Inject]
        public LoadSavedDataEvent(ISaveDataServiceForEvents saveDataService)
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