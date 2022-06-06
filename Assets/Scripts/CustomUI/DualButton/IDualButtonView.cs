using System;

namespace CustomUI.DualButton
{
    public interface IDualButtonView
    {
        event Action FirstKeyStrokeEvent;
        event Action SecondKeyStrokeEvent;
        void Activate();
        void Deactivate();
    }
}