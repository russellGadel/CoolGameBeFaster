using UnityEngine;

namespace CustomUI.UpperGamePlayPanel
{
    public sealed class UpperGamePlayPanelView : MonoBehaviour, IUpperGamePlayPanelView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}