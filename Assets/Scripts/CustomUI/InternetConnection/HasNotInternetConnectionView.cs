using UnityEngine;

namespace CustomUI.InternetConnection
{
    public sealed class HasNotInternetConnectionView : MonoBehaviour
        , IHasNotInternetConnectionView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void ShowWithBlinking()
        {
            Debug.Log("HasNotInternetConnectionView Play Animation");
        }

        public void StopAnyActions()
        {
            Debug.Log("HasNotInternetConnectionView Stop all actions");
        }
    }
}