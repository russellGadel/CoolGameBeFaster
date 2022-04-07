using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CustomUI.PlayerController.Mobile
{
    public sealed class PlayerControllerMobileView : MonoBehaviour
        , IPlayerControllerMobileView
        , IDragHandler
        , IPointerUpHandler
        , IPointerDownHandler
    {
        private PlayerControllerMobileSettings _mobileSettings;

        public void Construct(PlayerControllerMobileSettings mobileSettings)
        {
            _mobileSettings = mobileSettings;
        }


        private Vector2 _inputVector = Vector2.zero;

        public Vector2 GetInputVector()
        {
            return _inputVector;
        }

        [SerializeField] private Image _backgroundImg;
        [SerializeField] private Image _controllerImg;

        public void OnDrag(PointerEventData ped)
        {
            Debug.Log("On drag");

            Vector2 pos;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundImg.rectTransform,
                    ped.position,
                    ped.pressEventCamera,
                    out pos))
            {
                _inputVector = SolveInputVector(pos);

                Debug.Log("Input vector " + _inputVector);

                if (_inputVector.magnitude > 1.0f)
                {
                    _inputVector = _inputVector.normalized;
                }

                Debug.Log("Input vector normalized " + _inputVector);


                var delta = _backgroundImg.rectTransform.sizeDelta;


                _controllerImg.rectTransform.anchoredPosition = new Vector2(
                    _inputVector.x * (delta.x / _mobileSettings.dividerPosX)
                    , _inputVector.y * (delta.y / _mobileSettings.dividerPosY));
            }
        }


        public void OnPointerDown(PointerEventData ped)
        {
            OnDrag(ped);
        }


        public void OnPointerUp(PointerEventData ped)
        {
            _inputVector = Vector2.zero;
            _controllerImg.rectTransform.anchoredPosition = Vector2.zero;
        }

        private Vector2 SolveInputVector(Vector2 pos)
        {
            var sizeDelta = _backgroundImg.rectTransform.sizeDelta;

            pos.x = (pos.x / (sizeDelta.x));
            pos.y = (pos.y / (sizeDelta.y));

            return new Vector2(pos.x * _mobileSettings.multiplicityPosX + _mobileSettings.plusPosX,
                pos.y * _mobileSettings.multiplicityPosY -
                _mobileSettings.minusPosY);
        }
    }
}