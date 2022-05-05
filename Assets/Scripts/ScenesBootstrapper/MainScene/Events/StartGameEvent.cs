using System.Collections;
using Core.BootstrapExecutor;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class StartGameEvent : IBootstrapper
    {
        private readonly StartWindowEvent _startWindowEvent;

        [Inject]
        private StartGameEvent(StartWindowEvent startWindowEvent)
        {
            _startWindowEvent = startWindowEvent;
        }

        IEnumerator IBootstrapper.Execute()
        {
            _startWindowEvent.Execute();

            yield return null;
        }
    }
}