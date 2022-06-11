using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowView : MonoBehaviour
        , IReferencesListWindowView
    {
        public void Construct(in ReferencesListSettings referencesListSettings)
        {
            SetText(referencesListSettings.termsAndConditionsTable, referencesListSettings.privacyPolicyTable,
                referencesListSettings.feedbackTable);
        }

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

        [SerializeField] private TextMeshProUGUI _termsAndConditionsText;
        [SerializeField] private TextMeshProUGUI _privacyPolicyText;
        [SerializeField] private TextMeshProUGUI _feedbackText;

        private void SetText(in string termsAndConditions, in string privacyPolicy, in string feedback)
        {
            _termsAndConditionsText.SetText(termsAndConditions);
            _privacyPolicyText.SetText(privacyPolicy);
            _feedbackText.SetText(feedback);
        }
    }
}