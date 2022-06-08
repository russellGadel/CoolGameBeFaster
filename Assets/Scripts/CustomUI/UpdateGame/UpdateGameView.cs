using UnityEngine;
using UnityEngine.Events;
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

        public void SubscribeToPressUpdateButton(UnityAction observer)
        {
            _updateButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromPressUpdateButton(UnityAction observer)
        {
            _updateButton.onClick.RemoveListener(observer);
        }
    }
}