using System.Collections;
using Core.BootstrapExecutor;
using Core.EventsLoader;
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
        [Inject] private readonly LoadSavedDataEvent _loadSavedDataEvent;
        
        private void AddEvents()
        {
            _eventsLoader.Clear();
            _eventsLoader.AddEvent(_loadSavedDataEvent);
        }
    }
}