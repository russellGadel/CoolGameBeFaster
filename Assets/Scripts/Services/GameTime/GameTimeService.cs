using System;
using UnityEngine;

namespace Services.GameTime
{
    public class GameTimeService : IGameTimeService
    {
        private delegate void Observer();

        private event Observer PauseObservers;

        public void AddPlayerPauseObservers(Action observer)
        {
            PauseObservers += () => observer();
        }

        public void PlayerPause()
        {
            PauseObservers?.Invoke();
            Pause();
        }
        
        public void Pause()
        {
            Time.timeScale = 0;
        }


        private event Observer UnPauseObservers;

        public void AddPlayerUnpauseObservers(Action observer)
        {
            UnPauseObservers += () => observer();
        }

        public void PlayerUnpause()
        {
            UnPauseObservers?.Invoke();
            Unpause();
        }

        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}