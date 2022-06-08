using System;

namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowPresenter : IReferencesListWindowPresenter
        , IDisposable
    {
        private readonly IReferencesListWindowView _view;
        private readonly IReferencesListWindowModel _model;

        public ReferencesListWindowPresenter(in IReferencesListWindowModel model
            , in IReferencesListWindowView view)
        {
            _view = view;
            _model = model;

            SubscribeToTermsAndConditionsButton();
            SubscribeToPrivacyPolicyButton();
            SubscribeToFeedbackButton();
        }


        public void Open()
        {
            _view.Open();
        }

        public void Close()
        {
            _view.Close();
        }


        private void SubscribeToTermsAndConditionsButton()
        {
            _view.SubscribeToTermsAndConditionsButton(TermsAndConditionsButtonObservers);
        }

        private void TermsAndConditionsButtonObservers()
        {
            _model.OpenTermsAndConditionsURL();
        }


        private void SubscribeToPrivacyPolicyButton()
        {
            _view.SubscribeToPrivacyPolicyButton(PrivacyPolicyButtonObservers);
        }

        private void PrivacyPolicyButtonObservers()
        {
            _model.OpenPrivacyPolicyURL();
        }


        private void SubscribeToFeedbackButton()
        {
            _view.SubscribeToFeedbackButton(FeedbackButtonObservers);
        }

        private void FeedbackButtonObservers()
        {
            _model.OpenFeedbackURL();
        }


        void IDisposable.Dispose()
        {
            UnsubscribeFromTermsAndConditionsButton();
            UnsubscribeToPrivacyPolicyButton();
            UnsubscribeToFeedbackButton();
        }

        private void UnsubscribeFromTermsAndConditionsButton()
        {
            _view.UnsubscribeFromTermsAndConditionsButton(TermsAndConditionsButtonObservers);
        }

        private void UnsubscribeToPrivacyPolicyButton()
        {
            _view.UnsubscribeFromPrivacyPolicyButton(PrivacyPolicyButtonObservers);
        }

        private void UnsubscribeToFeedbackButton()
        {
            _view.UnsubscribeFromFeedbackButton(FeedbackButtonObservers);
        }
    }
}