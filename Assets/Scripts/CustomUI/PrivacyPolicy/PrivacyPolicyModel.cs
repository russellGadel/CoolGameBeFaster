using UnityEngine;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyModel : IPrivacyPolicyModel
    {
        private readonly PrivacyPolicySettings _settings;

        public PrivacyPolicyModel(PrivacyPolicySettings settings)
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
        
        
        
        private void OpenURL(string url)
        {
            try
            {
                Application.OpenURL(url);
            }
            catch
            {
                Debug.Log("Must open connect to internet connection");  
            }
        }


        private bool _isAcceptedAgreement = false;
        public bool IsAcceptedAgreement => _isAcceptedAgreement;
        
        public void UserAcceptPrivacyPolicy()
        {
            _isAcceptedAgreement = true;
        }
    }
}