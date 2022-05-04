using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.PauseButton
{
    [RequireComponent(typeof(Button))]
    public sealed class PauseButtonView : MonoBehaviour, IPauseButtonView
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

        public void AddObserverToPressButtonEvent(Action observer)
        {
            _button.onClick.AddListener(() => observer());
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }


        [SerializeField] private Image _playImage;

        private void OpenPlayImage()
        {
            _playImage.gameObject.SetActive(true);
        }

        private void ClosePlayImage()
        {
            _playImage.gameObject.SetActive(false);
        }

        [SerializeField] private Image _pauseImage;

        private void OpenPauseImage()
        {
            _pauseImage.gameObject.SetActive(true);
        }

        private void ClosePauseImage()
        {
            _pauseImage.gameObject.SetActive(false);
        }
    }
}