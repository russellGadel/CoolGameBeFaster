using System;

namespace CustomUI.StartWindow
{
    public interface IStartWindowView
    {
        void Load();
        void Open();
        void Close();
        void AddObserversToPressStartGameButton(Action observer);
    }
}