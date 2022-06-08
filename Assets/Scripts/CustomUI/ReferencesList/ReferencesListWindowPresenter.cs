namespace CustomUI.ReferencesList
{
    public sealed class ReferencesListWindowPresenter : IReferencesListWindowPresenter
    {
        private readonly IReferencesListWindowView _view;
        private readonly IReferencesListWindowModel _model;

        public ReferencesListWindowPresenter(in IReferencesListWindowModel model
            , in IReferencesListWindowView view)
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
            _view.SubscribeToTermsAndConditionsButton(TermsAndConditionsButtonObservers);
        }

        private void TermsAndConditionsButtonObservers()
        {
            _model.OpenTermsAndConditionsURL();
        }


        private void AddObserversToPrivacyPolicyButton()
        {
            _view.SubscribeToPrivacyPolicyButton(PrivacyPolicyButtonObservers);
        }

        private void PrivacyPolicyButtonObservers()
        {
            _model.OpenPrivacyPolicyURL();
        }


        private void AddObserversToFeedbackButton()
        {
            _view.SubscribeToFeedbackButton(FeedbackButtonObservers);
        }

        private void FeedbackButtonObservers()
        {
            _model.OpenFeedbackURL();
        }
    }
}