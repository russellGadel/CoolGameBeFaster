using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomUI.PauseButton
{
    [RequireComponent(typeof(Button))]
    public sealed class PauseButtonView : MonoBehaviour
        , IPauseButtonView
    {
        private Button _button;

        public IEnumerator Install()
        {
            _button = GetComponent<Button>();
            _button.onClick.RemoveAllListeners();
            ClosePlayImage();

            yield return null;
        }


        public void SetPlayView()
        {
            ClosePauseImage();
            OpenPlayImage();
        }

        public void SetPauseView()
        {
            ClosePlayImage();
            OpenPauseImage();
        }

        public void SubscribeToPressButtonEvent(UnityAction observer)
        {
            _button.onClick.AddListener(observer);
        }

        public void UnsubscribeFromPressButtonEvent(UnityAction observer)
        {
            _button.onClick.RemoveListener(observer);
        }


        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }


        [SerializeField] private GameObject _playImage;

        private void OpenPlayImage()
        {
            _playImage.SetActive(true);
        }

        private void ClosePlayImage()
        {
            _playImage.SetActive(false);
        }


        [SerializeField] private GameObject _pauseImage;

        private void OpenPauseImage()
        {
            _pauseImage.SetActive(true);
        }

        private void ClosePauseImage()
        {
            _pauseImage.SetActive(false);
        }
    }
}