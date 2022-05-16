using System;

namespace CustomUI.PrivacyPolicy
{
    public interface IPrivacyPolicyView
    {
        public void AddObserverToTermsAndConditionsButton(Action observerAction);
        public void AddObserverToPrivacyPolicyButton(Action observerAction);
        public void AddObserverToAcceptButton(Action observerAction);
        public void AddObserverToDeclineButton(Action observerAction);
        public void Open();
        public void Close();
    }
}
