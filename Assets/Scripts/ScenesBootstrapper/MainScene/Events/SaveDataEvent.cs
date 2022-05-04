using Core.EventsLoader;
using Services.SaveData;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class SaveDataEvent : ICustomEvent
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
    }
}