namespace CustomUI.PrivacyPolicy
{
    public interface IPrivacyPolicyModel
    {
        void OpenTermsAndConditionsURL();
        void OpenPrivacyPolicyURL();
        void UserAcceptPrivacyPolicy();
        bool IsAcceptedAgreement { get; }
    }
}