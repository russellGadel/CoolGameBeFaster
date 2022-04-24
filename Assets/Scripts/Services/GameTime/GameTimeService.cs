using System;
using UnityEngine;

namespace Services.GameTime
{
    public class GameTimeService : IGameTimeService
    {
        public void Pause()
        {
            Time.timeScale = 0;
        }
        
        public void Unpause()
        {
            Time.timeScale = 1;
        }
    }
}