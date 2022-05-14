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

        private int _pressCounter = 0;

        private void PressButton()
        {
            _pressCounter += 1;

            if (_pressCounter == 1)
            {
                _firstKeyStroke?.Invoke();
            }
            else
            {
                ZeroingPressCounter();
                _secondKeyStroke?.Invoke();
            }
        }

        private void ZeroingPressCounter()
        {
            _pressCounter = 0;
        }

        private delegate void Observer();

        private Observer _firstKeyStroke = null;

        public void AddObserverToFirstKeyStroke(Action observer)
        {
            _firstKeyStroke += () => observer();
        }

        private Observer _secondKeyStroke = null;

        public void AddObserverToSecondKeyStroke(Action observer)
        {
            _secondKeyStroke += () => observer();
        }


        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }
    }
}