using System;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowView : MonoBehaviour, IReferencesListWindowView
    {
        [SerializeField] private Button _termsAndConditionsButton;

        public void AddObserversToTermsAndConditionsButton(Action observer)
        {
            _termsAndConditionsButton.onClick.AddListener(() => observer());
        }


        [SerializeField] private Button _privacyPolicyButton;

        public void AddObserversToPrivacyPolicyButton(Action observer)
        {
            _privacyPolicyButton.onClick.AddListener(() => observer());
        }


        [SerializeField] private Button _feedbackButton;

        public void AddObserversToFeedbackButton(Action observer)
        {
            _feedbackButton.onClick.AddListener(() => observer());
        }


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