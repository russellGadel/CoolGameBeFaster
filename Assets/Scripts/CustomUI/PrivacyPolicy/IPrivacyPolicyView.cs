using UnityEngine.Events;

namespace CustomUI.PrivacyPolicy
{
    public interface IPrivacyPolicyView
    {
        public void Open();
        public void Close();
        
        public void SubscribeToTermsAndConditionsButton(UnityAction observer);
        public void UnsubscribeFromTermsAndConditionsButton(UnityAction observer);

        public void SubscribeToPrivacyPolicyButton(UnityAction observer);
        public void UnsubscribeFromPrivacyPolicyButton(UnityAction observer);

        public void SubscribeToAcceptButton(UnityAction observer);
        public void UnsubscribeFromAcceptButton(UnityAction observer);

        public void SubscribeToDeclineButton(UnityAction observer);
        public void UnsubscribeFromDeclineButton(UnityAction observer);
    }
}
