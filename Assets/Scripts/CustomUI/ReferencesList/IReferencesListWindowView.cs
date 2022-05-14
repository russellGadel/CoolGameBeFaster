using System;

namespace  CustomUI.ReferencesList
{
    public interface IReferencesListWindowView
    {
        void AddObserversToTermsAndConditionsButton(Action observer);
        void AddObserversToPrivacyPolicyButton(Action observer);
        void AddObserversToFeedbackButton(Action observer);
        void Open();
        void Close();
    }
}