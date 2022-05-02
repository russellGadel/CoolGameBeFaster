using System;
using Core.InstallersExecutor;

namespace CustomUI.GameOverView
{
    public interface IGameOverView : ICustomInstaller
    {
        void Open();
        void Close();
        void AddObserverToRepeatButton(Action observer);
        void SetCurrentPointsAmount(double points);
        void SetMaxPointsAmount(double points);
    }
}