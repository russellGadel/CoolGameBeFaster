using System;
using UnityEngine;
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
    
        public void AddObserverToTermsAndConditionsButton(Action observerAction)
        {
            _termsAndConditionsButton.onClick.AddListener(() => observerAction());
        }

    

        [SerializeField] private Button _privacyPolicyButton;

        public void AddObserverToPrivacyPolicyButton(Action observerAction)
        {
            _privacyPolicyButton.onClick.AddListener(() => observerAction());
        }

    
        [SerializeField] private Button _acceptButton;
    
        public void AddObserverToAcceptButton(Action observerAction)
        {
            _acceptButton.onClick.AddListener(() => observerAction());
        }

    
        [SerializeField] private Button _declineButton;

        public void AddObserverToDeclineButton(Action observerAction)
        {
            _declineButton.onClick.AddListener(() => observerAction());
        }
    }
}