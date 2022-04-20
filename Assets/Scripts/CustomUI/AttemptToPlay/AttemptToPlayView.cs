using UnityEngine;

namespace CustomUI.AttemptToPlay
{
    public class AttemptToPlayView : MonoBehaviour, IAttemptToPlayView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void CLose()
        {
            gameObject.SetActive(false);
        }
        
    }
}