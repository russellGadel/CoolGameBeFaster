using System;

namespace CustomUI.PlayerAccelerationButton
{
    public interface IPlayerAccelerationButtonView
    {
        void AddObserverToOnPointerDownEvent(Action observer);
        void AddObserverOnPointerUpEvent(Action observer);
        void Open();
        void Close();
    }
}