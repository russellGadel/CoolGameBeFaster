using UnityEngine;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowModel :
        IReferencesListWindowModel
    {
        private readonly ReferencesListSettings _settings;

        public ReferencesListWindowModel(in ReferencesListSettings settings)
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


        public void OpenFeedbackURL()
        {
            OpenURL(_settings.feedbackURL);
        }


        private void OpenURL(in string url)
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
    }
}