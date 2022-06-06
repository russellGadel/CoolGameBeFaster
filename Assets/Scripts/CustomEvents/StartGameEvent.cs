using System.Collections;
using Core.BootstrapExecutor;
using Zenject;

namespace CustomEvents
{
    public sealed class StartGameEvent : IBootstrapper
    {
        private readonly StartWindowEvents _startWindowEvents;

        [Inject]
        private StartGameEvent(StartWindowEvents startWindowEvents)
        {
            _startWindowEvents = startWindowEvents;
        }

        IEnumerator IBootstrapper.Execute()
        {
            _startWindowEvents.Execute();

            yield return null;
        }
    }
}