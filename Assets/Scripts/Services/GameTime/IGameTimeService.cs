using System;

namespace Services.GameTime
{
    public interface IGameTimeService
    {
        void AddPlayerPauseObservers(Action observer);
        void PlayerPause();
        void Pause();
        void AddPlayerUnpauseObservers(Action observer);
        void PlayerUnpause();
        void Unpause();
    }
}