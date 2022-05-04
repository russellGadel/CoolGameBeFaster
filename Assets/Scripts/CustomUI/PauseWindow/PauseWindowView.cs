using UnityEngine;

namespace CustomUI.PauseWindow
{
    public class PauseWindowView : MonoBehaviour
        , IPauseWindow
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