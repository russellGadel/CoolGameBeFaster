using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.GameOverView
{
    public class GameOverView : MonoBehaviour, IGameOverView
    {
        [SerializeField] private Button _repeatButton;

        public IEnumerator Install()
        {
            _repeatButton.onClick.RemoveAllListeners();
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
    }
}