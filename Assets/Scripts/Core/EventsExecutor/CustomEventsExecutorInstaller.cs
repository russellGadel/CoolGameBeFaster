using UnityEngine;
using Zenject;

namespace Core.EventsExecutor
{
    public class CustomEventsExecutorInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindEventsExecutor();
        }


        [SerializeField] private CustomEventsExecutor _eventsExecutor;

        private void BindEventsExecutor()
        {
            Container
                .Bind<ICustomEventsExecutor>()
                .To<CustomEventsExecutor>()
                .FromInstance(_eventsExecutor)
                .AsSingle();
        }
    }
}