using TMPro;
using UnityEngine;

namespace CustomUI.LoadingWindow
{
    public sealed class LoadingWindowView : MonoBehaviour
        , ILoadingWindowView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        [SerializeField] private TextMeshProUGUI _gameVersion;

        public void SetGameVersion(in string gameVersion)
        {
            _gameVersion.SetText(gameVersion);
        }
    }
}