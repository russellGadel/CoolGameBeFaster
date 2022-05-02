using System;
using Core.EventsLoader;
using Core.InstallersExecutor;

namespace CustomUI.GameOverView
{
    public interface IGameOverView : ICustomInstaller
    {
        void Open();
        void Close();
        void AddObserverToRepeatButton(Action observer);
    }
}