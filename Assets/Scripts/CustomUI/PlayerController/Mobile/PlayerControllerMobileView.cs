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
                Vector2 backgroundImgRecTransformSizeDelta = _backgroundImg.rectTransform.sizeDelta;
                SolveInputVector(ref _dragPosition, in backgroundImgRecTransformSizeDelta, ref _inputVector);

                _controllerImg.rectTransform.anchoredPosition = new Vector2(
                    _inputVector.x * (backgroundImgRecTransformSizeDelta.x / _mobileSettings.dividerPosX)
                    , _inputVector.y * (backgroundImgRecTransformSizeDelta.y / _mobileSettings.dividerPosY));
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

        private void SolveInputVector(ref Vector2 pos
            , in Vector2 backgroundImgRecTransformSizeDelta
            , ref Vector2 inputVector)
        {
            pos.Set(pos.x / (backgroundImgRecTransformSizeDelta.x), pos.y / (backgroundImgRecTransformSizeDelta.y));

            inputVector.Set(pos.x * _mobileSettings.multiplicityPosX + _mobileSettings.plusPosX,
                pos.y * _mobileSettings.multiplicityPosY - _mobileSettings.minusPosY);

            if (_inputVector.magnitude > 1.0f)
            {
                _inputVector = _inputVector.normalized;
            }
        }
    }
}