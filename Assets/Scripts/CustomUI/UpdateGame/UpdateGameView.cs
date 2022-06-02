using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.UpdateGame
{
    public sealed class UpdateGameView : MonoBehaviour
        , IUpdateGameView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }


        [SerializeField] private Button _updateButton;

        public void AddObserverToPressUpdateButtonEvent(Action observer)
        {
            _updateButton.onClick.AddListener(() => observer());
        }
    }
}