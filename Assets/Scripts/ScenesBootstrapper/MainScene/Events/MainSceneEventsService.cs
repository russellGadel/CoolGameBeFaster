using ScenesBootstrapper.MainScene.Events.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public class MainSceneEventsService
    {
        [Inject] public PlayerPauseEvent PlayerPauseEvent;
        [Inject] public PlayerUnpauseEvent PlayerUnpauseEvent;
        [Inject] public AttemptToPlayEvent AttemptToPlayEvent;
        [Inject] public SaveDataEvent SaveDataEvent;
    }
}