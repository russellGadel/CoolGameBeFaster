using Core.InstallersExecutor;
using UnityEngine.Events;

namespace CustomUI.PauseButton
{
    public interface IPauseButtonView : ICustomInstaller
    {
        void SetPlayView();
        void SetPauseView();
        void SubscribeToPressButtonEvent(UnityAction observer);
        void UnsubscribeFromPressButtonEvent(UnityAction observer);
        void Activate();
        void Deactivate();
    }
}