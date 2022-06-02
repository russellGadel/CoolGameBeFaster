using System;

namespace CustomUI.UpdateGame
{
    public interface IUpdateGameView
    {
        void Open();
        void Close();
        void AddObserverToPressUpdateButtonEvent(Action observer);
    }
}