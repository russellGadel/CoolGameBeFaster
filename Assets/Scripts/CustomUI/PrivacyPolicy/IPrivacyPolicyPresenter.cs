using System;

namespace CustomUI.PrivacyPolicy
{
    public interface IPrivacyPolicyPresenter
    {
        void Open();
        void Close();
        void AddObserverToAcceptButton(Action observer);
        void AddObserverToDeclineButton(Action observer);
        void UserAcceptPrivacyPolicy();
        bool IsAcceptAgreement();
    }
}