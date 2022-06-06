using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.DualButton
{
    [RequireComponent(typeof(Button))]
    public sealed class DualButtonView : MonoBehaviour
        , IDualButtonView
    {
        private Button _button;

        public void Construct()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PressButton);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }


        private int _pressCounter = 0;

        public event Action FirstKeyStrokeEvent;
        public event Action SecondKeyStrokeEvent;

        private void PressButton()
        {
            _pressCounter += 1;

            if (_pressCounter == 1)
            {
                FirstKeyStrokeEvent?.Invoke();
            }
            else
            {
                ZeroingPressCounter();
                SecondKeyStrokeEvent?.Invoke();
            }
        }

        private void ZeroingPressCounter()
        {
            _pressCounter = 0;
        }
    }
}