using System;
using Core.InstallersExecutor;

namespace CustomUI.StartWindow
{
    public interface IStartWindowView : ICustomInstaller
    {
        void Open();
        void Close();
        void AddObserversToPressStartGameButton(Action observer);
        void SetMaxPoints(string maxPoints);
        void AddObserversToFirstPressOnReferencesListButton(Action observer);
        void AddObserversToSecondPressOnReferencesListButton(Action observer);
    }
}