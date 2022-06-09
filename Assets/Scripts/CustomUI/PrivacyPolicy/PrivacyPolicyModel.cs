using UnityEngine;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyModel : IPrivacyPolicyModel
    {
        private readonly PrivacyPolicySettings _settings;

        public PrivacyPolicyModel(in PrivacyPolicySettings settings)
        {
            _settings = settings;
        }


        public void OpenTermsAndConditionsURL()
        {
            OpenURL(_settings.termsAndConditionsURL);
        }

        public void OpenPrivacyPolicyURL()
        {
            OpenURL(_settings.privacyPolicyURL);
        }


        private void OpenURL(in string url)
        {
            Application.OpenURL(url);
        }


        private bool _isAcceptedAgreement = false;
        public bool IsAcceptedAgreement => _isAcceptedAgreement;

        public void UserAcceptPrivacyPolicy()
        {
            _isAcceptedAgreement = true;
        }
    }
}