using System.ComponentModel;
using ScenesBootstrapper.MainScene.Events.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class MainSceneEventsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPauseEvent();
            BindUnpauseEvent();
        }
        
        
        private void BindPauseEvent()
        {
            Container.Bind<PlayerPauseEvent>().AsSingle();
        }
        
        private void BindUnpauseEvent()
        {
            Container.Bind<PlayerUnpauseEvent>().AsSingle();
        }
    }
}