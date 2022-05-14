using System;

namespace CustomUI.DualButton
{
    public interface IDualButtonView
    {
        void AddObserverToFirstKeyStroke(Action observer);
        void AddObserverToSecondKeyStroke(Action observer);
        void Activate();
        void Deactivate();
    }
}