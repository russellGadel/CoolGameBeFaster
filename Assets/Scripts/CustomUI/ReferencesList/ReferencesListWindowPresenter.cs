namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowPresenter : IReferencesListWindowPresenter
    {
        private IReferencesListWindowView _view;
        private IReferencesListWindowModel _model;

        public ReferencesListWindowPresenter(IReferencesListWindowModel model
            , IReferencesListWindowView view)
        {
            _view = view;
            _model = model;

            AddObserversToTermsAndConditionsButton();
            AddObserversToPrivacyPolicyButton();
            AddObserversToFeedbackButton();
        }


        public void Open()
        {
            _view.Open();
        }

        public void Close()
        {
            _view.Close();
        }


        private void AddObserversToTermsAndConditionsButton()
        {
            _view.AddObserversToTermsAndConditionsButton(TermsAndConditionsButtonObservers);
        }

        private void TermsAndConditionsButtonObservers()
        {
            _model.OpenTermsAndConditionsURL();
        }


        private void AddObserversToPrivacyPolicyButton()
        {
            _view.AddObserversToPrivacyPolicyButton(PrivacyPolicyButtonObservers);
        }

        private void PrivacyPolicyButtonObservers()
        {
            _model.OpenPrivacyPolicyURL();
        }


        private void AddObserversToFeedbackButton()
        {
            _view.AddObserversToFeedbackButton(FeedbackButtonObservers);
        }

        private void FeedbackButtonObservers()
        {
            _model.OpenFeedbackURL();
        }
    }
}