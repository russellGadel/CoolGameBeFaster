using UnityEngine.Events;

namespace CustomUI.ReferencesList
{
    public interface IReferencesListWindowView
    {
        void Open();
        void Close();

        void SubscribeToTermsAndConditionsButton(UnityAction observer);
        void UnsubscribeFromTermsAndConditionsButton(UnityAction observer);

        void SubscribeToPrivacyPolicyButton(UnityAction observer);
        void UnsubscribeFromPrivacyPolicyButton(UnityAction observer);

        void SubscribeToFeedbackButton(UnityAction observer);
        void UnsubscribeFromFeedbackButton(UnityAction observer);
    }
}