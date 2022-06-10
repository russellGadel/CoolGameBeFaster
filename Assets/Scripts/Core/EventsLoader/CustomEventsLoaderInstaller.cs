using UnityEngine;
using Zenject;

namespace Core.EventsLoader
{
    public sealed class CustomEventsLoaderInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEventsLoader();
        }


        [SerializeField] private CustomEventsLoader eventsLoader;

        private void BindEventsLoader()
        {
            Container
                .Bind<ICustomEventsLoader>()
                .To<CustomEventsLoader>()
                .FromInstance(eventsLoader)
                .AsSingle();
        }
    }
}