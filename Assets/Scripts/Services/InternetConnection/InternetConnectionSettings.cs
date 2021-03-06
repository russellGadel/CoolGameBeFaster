using UnityEngine;

namespace Services.InternetConnection
{
    public sealed class InternetConnectionSettings : MonoBehaviour
    {
        public int attemptAmountToConnectToFirstURL;
        public float delayTimeForNextCheckConnectionAfterFailedAttempt;
        public string firstURLForCheckInternetConnection;
        public string secondURLForCheckInternetConnection;
    }
}