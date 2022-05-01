using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class ContinueGameAfterTakeAttemptToPlayEvent : ICustomEvent
    {
        [Inject] private readonly IAttemptToPlayView _attemptToPlayView;

        public void Execute()
        {
            _attemptToPlayView.Close();
        }
    }
}