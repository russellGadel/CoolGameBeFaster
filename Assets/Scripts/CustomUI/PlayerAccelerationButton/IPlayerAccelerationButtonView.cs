using System;

namespace CustomUI.PlayerAccelerationButton
{
    public interface IPlayerAccelerationButtonView
    {
        void SubscribeToOnPointerDownEvent(Action observer);
        void UnsubscribeFromOnPointerDownEvent(Action observer);

        void SubscribeOnPointerUpEvent(Action observer);
        void UnsubscribeFromOnPointerUpEvent(Action observer);

        void Open();
        void Close();
    }
}