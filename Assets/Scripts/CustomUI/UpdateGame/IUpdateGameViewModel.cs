using System;

namespace CustomUI.UpdateGame
{
    public interface IUpdateGameViewModel
    {
        void OpenView();
        void CloseView();
        void GoToAppStore();
        void AddObserverToUpdateButton(Action observer);
    }
}