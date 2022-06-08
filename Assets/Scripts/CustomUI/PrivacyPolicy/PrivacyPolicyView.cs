using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyView : MonoBehaviour
        , IPrivacyPolicyView
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


        [SerializeField] private Button _acceptButton;

        public void SubscribeToAcceptButton(UnityAction observer)
        {
            _acceptButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromAcceptButton(UnityAction observer)
        {
            _acceptButton.onClick.RemoveListener(observer);
        }


        [SerializeField] private Button _declineButton;

        public void SubscribeToDeclineButton(UnityAction observer)
        {
            _declineButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromDeclineButton(UnityAction observer)
        {
            _declineButton.onClick.RemoveListener(observer);
        }
    }
}