using Zenject;

namespace Services.SaveData
{
    public class SaveDataServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindSaveService();
            BindSaveServiceFoEvents();
        }
        
        private readonly SaveDataService _saveDataService = new SaveDataService();
        
        private void BindSaveService()
        {
            Container
                .Bind<ISaveDataService>()
                .FromInstance(_saveDataService)
                .AsSingle();
        }
        
        private void BindSaveServiceFoEvents()
        {
            Container
                .Bind<ISaveDataServiceForEvents>()
                .FromInstance(_saveDataService)
                .AsSingle();
        }
    }
}