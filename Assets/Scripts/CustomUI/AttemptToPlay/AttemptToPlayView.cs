using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.AttemptToPlay
{
    public sealed class AttemptToPlayView : MonoBehaviour, IAttemptToPlayView
    {
        [SerializeField] private Button _repeatButton;
        [SerializeField] private Button _advertisingButton;

        public IEnumerator Install()
        {
            _repeatButton.onClick.RemoveAllListeners();
            _advertisingButton.onClick.RemoveAllListeners();
            yield return null;
        }


        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            Debug.Log("Close Attempt window");
            gameObject.SetActive(false);
        }


        public void AddObserverToRepeatButton(Action observer)
        {
            _repeatButton.onClick.AddListener(() => observer());
        }

        public void AddObserverToAdvertisingButton(Action observer)
        {
            _advertisingButton.onClick.AddListener(() => observer());
        }


        [SerializeField] private TextMeshProUGUI _currentPointsText;

        public void SetCurrentPointsAmount(double points)
        {
            _currentPointsText.SetText(points.ToString());
        }


        [SerializeField] private TextMeshProUGUI _maxPointsText;

        public void SetMaxPointsAmount(double points)
        {
            _maxPointsText.SetText(points.ToString());
        }

        public void SetAdvertisementButtonInteractableValue(bool value)
        {
            _advertisingButton.interactable = value;
        }
    }
}