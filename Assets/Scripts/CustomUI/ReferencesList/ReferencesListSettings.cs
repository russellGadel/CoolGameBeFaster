using System;
using UnityEngine;

namespace CustomUI.ReferencesList
{
    [Serializable]
    public struct ReferencesListSettings
    {
        [Header("TermsAndConditions")] 
        public string termsAndConditionsTable;
        public string termsAndConditionsURL;

        [Header("Privacy policy")]
        public string privacyPolicyTable;
        public string privacyPolicyURL;

        [Header("Feedback")]
        public string feedbackTable;
        public string feedbackURL;
    }
}