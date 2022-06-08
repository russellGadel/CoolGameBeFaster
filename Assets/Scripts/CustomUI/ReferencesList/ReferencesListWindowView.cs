using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowView : MonoBehaviour
        , IReferencesListWindowView
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }


        [SerializeField] private Button _termsAndConditionsButton;

        public void SubscribeToTermsAndConditionsButton(UnityAction observer)
        {
            _termsAndConditionsButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromTermsAndConditionsButton(UnityAction observer)
        {
            _termsAndConditionsButton.onClick.RemoveListener(observer);
        }


        [SerializeField] private Button _privacyPolicyButton;

        public void SubscribeToPrivacyPolicyButton(UnityAction observer)
        {
            _privacyPolicyButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromPrivacyPolicyButton(UnityAction observer)
        {
            _privacyPolicyButton.onClick.RemoveListener(observer);
        }

        
        [SerializeField] private Button _feedbackButton;

        public void SubscribeToFeedbackButton(UnityAction observer)
        {
            _feedbackButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromFeedbackButton(UnityAction observer)
        {
            _feedbackButton.onClick.RemoveListener(observer);
        }
    }
}