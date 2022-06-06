using System;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyPresenter : IPrivacyPolicyPresenter
    {
        private readonly IPrivacyPolicyView _view;
        private readonly IPrivacyPolicyModel _model;

        public PrivacyPolicyPresenter(IPrivacyPolicyView view
            , IPrivacyPolicyModel model)
        {
            _view = view;
            _model = model;

            AddObserversToView();
        }


        public void Open()
        {
            _view.Open();
        }

        public void Close()
        {
            _view.Close();
        }


        public void AddObserverToAcceptButton(Action observer)
        {
            _view.AddObserverToAcceptButton(observer);
        }

        public void AddObserverToDeclineButton(Action observer)
        {
            _view.AddObserverToDeclineButton(observer);
        }


        public void UserAcceptPrivacyPolicy()
        {
            _model.UserAcceptPrivacyPolicy();
        }


        public bool IsAcceptAgreement()
        {
            return _model.IsAcceptedAgreement;
        }


        private void AddObserversToView()
        {
            AddObserverToTermsAndConditionsButton();
            AddObserverToPrivacyPolicyButton();
        }

        private void AddObserverToTermsAndConditionsButton()
        {
            _view.AddObserverToTermsAndConditionsButton(_model.OpenTermsAndConditionsURL);
        }

        private void AddObserverToPrivacyPolicyButton()
        {
            _view.AddObserverToPrivacyPolicyButton(_model.OpenPrivacyPolicyURL);
        }
    }
}