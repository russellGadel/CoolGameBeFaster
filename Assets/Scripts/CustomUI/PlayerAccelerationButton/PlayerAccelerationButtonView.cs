using System;
using System.Collections;
using UnityEngine.EventSystems;

namespace CustomUI.PlayerAccelerationButton
{
    public sealed class PlayerAccelerationButtonView : EventTrigger, IPlayerAccelerationButtonView
    {
        private delegate void Observer();

        private event Observer OnPointerDownObservers = null;

        public void AddObserverToOnPointerDownEvent(Action observer)
        {
            OnPointerDownObservers += () => observer();
        }

        private event Observer OnPointerUpObservers = null;

        public void AddObserverOnPointerUpEvent(Action observer)
        {
            OnPointerUpObservers += () => observer();
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