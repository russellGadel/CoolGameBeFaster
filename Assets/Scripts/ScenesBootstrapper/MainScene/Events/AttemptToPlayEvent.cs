using Core.EventsLoader;
using CustomUI.AttemptToPlay;
using Services.SaveData;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class AttemptToPlayEvent : ICustomEvent
    {
        private readonly IAttemptToPlayView _attemptToPlayView;
        
        [Inject]
        public AttemptToPlayEvent(IAttemptToPlayView attemptToPlayView)
        {
            _attemptToPlayView = attemptToPlayView;
        }

        public void Execute()
        {
            _attemptToPlayView.Open();
        }
    }
}