using System;
using Core.InstallersExecutor;

namespace CustomUI.PauseButton
{
    public interface IPauseButtonView : ICustomInstaller
    {
        void SetPlayView();
        void SetPauseView();
        void AddObserverToPressButtonEvent(Action observer);
        void Activate();
        void Deactivate();
    }
}