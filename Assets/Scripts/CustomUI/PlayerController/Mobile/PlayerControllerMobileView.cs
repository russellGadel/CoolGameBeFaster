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

        public void Construct(in PlayerControllerMobileSettings mobileSettings)
        {
            _mobileSettings = mobileSettings;
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }


        private Vector2 _inputVector = Vector2.zero;

        public Vector2 GetInputVector()
        {
            return _inputVector;
        }

        [SerializeField] private Image _backgroundImg;
        [SerializeField] private Image _controllerImg;

        private Vector2 _dragPosition = new Vector2();

        public void OnDrag(PointerEventData ped)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundImg.rectTransform,
                    ped.position,
                    ped.pressEventCamera,
                    out _dragPosition))
            {
                SolveInputVector(_dragPosition, ref _inputVector);

                if (_inputVector.magnitude > 1.0f)
                {
                    _inputVector = _inputVector.normalized;
                }

                Vector2 delta = _backgroundImg.rectTransform.sizeDelta;

                _controllerImg.rectTransform.anchoredPosition.Set(
                    _inputVector.x * (delta.x / _mobileSettings.dividerPosX),
                    _inputVector.y * (delta.y / _mobileSettings.dividerPosY));
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

        private void SolveInputVector(in Vector2 pos, ref Vector2 inputVector)
        {
            Vector2 sizeDelta = _backgroundImg.rectTransform.sizeDelta;
            pos.Set(pos.x / (sizeDelta.x), pos.y / (sizeDelta.y));

            inputVector.Set(pos.x * _mobileSettings.multiplicityPosX + _mobileSettings.plusPosX,
                pos.y * _mobileSettings.multiplicityPosY -
                _mobileSettings.minusPosY);
        }
    }
}