 using UnityEngine.Events;

namespace CustomUI.PrivacyPolicy
{
    public interface IPrivacyPolicyPresenter
    {
        void Open();
        void Close();
        
        void SubscribeToAcceptButton(UnityAction observer);
        void UnsubscribeFromAcceptButton(UnityAction observer);
        
        void SubscribeToDeclineButton(UnityAction observer);
        void UnsubscribeFromDeclineButton(UnityAction observer);
        
        void UserAcceptPrivacyPolicy();
        bool IsAcceptAgreement();
    }
}