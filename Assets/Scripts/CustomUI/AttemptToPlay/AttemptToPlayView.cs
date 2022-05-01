using System;
using System.Collections;
using Core.InstallersExecutor;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.AttemptToPlay
{
    public class AttemptToPlayView : MonoBehaviour, IAttemptToPlayView
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
    }
}