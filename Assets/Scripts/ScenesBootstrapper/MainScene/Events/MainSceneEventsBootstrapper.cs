using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsLoader;
using ScenesBootstrapper.MainScene.Events.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class MainSceneEventsBootstrapper : IBootstrapper
    {
        public IEnumerator Execute()
        {
            AddEvents();
            yield return null;
        }

        [Inject] private readonly ICustomEventsLoader _eventsLoader;

        private void AddEvents()
        {
            _eventsLoader.Clear();
           
        }
    }
}