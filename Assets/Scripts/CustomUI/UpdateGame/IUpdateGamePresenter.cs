using System;

namespace CustomUI.UpdateGame
{
    public interface IUpdateGamePresenter
    {
        void OpenView();
        void CloseView();
        void GoToAppStore();
        void AddObserverToUpdateButton(Action observer);
    }
}