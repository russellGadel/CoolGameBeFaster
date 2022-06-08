using CustomEvents;
using CustomEvents.GameTime;
using Zenject;

namespace ScenesBootstrapper.MainScene.Events
{
    public sealed class MainSceneEventsService
    {
        [Inject] public PlayerPauseEvent PlayerPauseEvent;
        [Inject] public PlayerUnpauseEvent PlayerUnpauseEvent;
        [Inject] public AttemptToPlayWindowEvents AttemptToPlayWindowEvents;
        [Inject] public GameOverWindowEvents GameOverWindowEvents;
        [Inject] public SaveDataEvent SaveDataEvent;
    }
}