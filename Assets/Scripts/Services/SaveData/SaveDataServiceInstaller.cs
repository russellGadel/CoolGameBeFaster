using Zenject;

namespace Services.SaveData
{
    public class SaveDataServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ISaveDataService>()
                .To<SaveDataService>()
                .AsSingle();
        }
    }
}