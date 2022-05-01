using UnityEngine;

namespace CustomUI.GameOverView
{
    public class GameOverView : MonoBehaviour, IGameOverView
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