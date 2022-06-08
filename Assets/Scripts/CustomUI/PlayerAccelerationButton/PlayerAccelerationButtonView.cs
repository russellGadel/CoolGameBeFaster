using System;
using System.Collections;
using UnityEngine.EventSystems;

namespace CustomUI.PlayerAccelerationButton
{
    public sealed class PlayerAccelerationButtonView :
        EventTrigger
        , IPlayerAccelerationButtonView
    {
        private event Action OnPointerDownObservers = null;

        public void SubscribeToOnPointerDownEvent(Action observer)
        {
            OnPointerDownObservers += observer;
        }

        public void UnsubscribeFromOnPointerDownEvent(Action observer)
        {
            OnPointerDownObservers -= observer;
        }


        private event Action OnPointerUpObservers = null;

        public void SubscribeOnPointerUpEvent(Action observer)
        {
            OnPointerUpObservers += observer;
        }

        public void UnsubscribeFromOnPointerUpEvent(Action observer)
        {
            OnPointerUpObservers += observer;
        }


        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerDown(eventData);

            OnPointerDownObservers?.Invoke();
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            OnPointerUpObservers?.Invoke();
        }
    }
}