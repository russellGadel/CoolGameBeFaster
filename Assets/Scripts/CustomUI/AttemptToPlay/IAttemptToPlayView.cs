using System;
using System.Collections;
using Core.InstallersExecutor;

namespace CustomUI.AttemptToPlay
{
    public interface IAttemptToPlayView : ICustomInstaller
    {
        void Open();
        void Close();
        void AddObserverToRepeatButton(Action observer);
        void AddObserverToAdvertisingButton(Action observer);
        void SetCurrentPointsAmount(double points);
        void SetMaxPointsAmount(double points);
    }
}