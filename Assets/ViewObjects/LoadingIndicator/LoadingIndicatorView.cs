using UnityEngine;

namespace  ViewObjects.LoadingIndicator
{
    public sealed class LoadingIndicatorView : MonoBehaviour
        , ILoadingIndicatorView
    {
        [SerializeField] private ParticleSystem ringEffect;

        public void Open()
        {
            gameObject.SetActive(true);
            ringEffect.Play();
        }

        public void Close()
        {
            ringEffect.Stop();
            gameObject.SetActive(false);
        }
    }
}
