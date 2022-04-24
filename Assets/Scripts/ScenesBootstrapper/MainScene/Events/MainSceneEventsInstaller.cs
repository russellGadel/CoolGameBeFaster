using System.ComponentModel;
using ScenesBootstrapper.MainScene.Events.GameTime;
using Services.SaveData;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class MainSceneEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPauseEvent();
            BindUnpauseEvent();
            BindSaveDataEvent();
            
            BindLoadSavedDataEvent();
            
            BindMainSceneEventsService();
        }

        
        private void BindPauseEvent()
        {
            Container.Bind<PlayerPauseEvent>().AsSingle();
        }
        
        private void BindUnpauseEvent()
        {
            Container.Bind<PlayerUnpauseEvent>().AsSingle();
        }
        
        private void BindSaveDataEvent()
        {
            Container.Bind<SaveDataEvent>().AsSingle();
        }

        private void BindLoadSavedDataEvent()
        {
            Container.Bind<LoadSavedDataEvent>().AsSingle();
        }

        private void BindMainSceneEventsService()
        {
            Container.Bind<MainSceneEventsService>().AsSingle();
        }
    }
}