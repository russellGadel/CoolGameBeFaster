using System;
using UnityEngine.Events;

namespace CustomUI.PrivacyPolicy
{
    public sealed class PrivacyPolicyPresenter :
        IPrivacyPolicyPresenter,
        IDisposable
    {
        private readonly IPrivacyPolicyView _view;
        private readonly IPrivacyPolicyModel _model;

        public PrivacyPolicyPresenter(IPrivacyPolicyView view
            , in IPrivacyPolicyModel model)
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


        public void SubscribeToAcceptButton(UnityAction observer)
        {
            _view.SubscribeToAcceptButton(observer);
        }

        public void UnsubscribeFromAcceptButton(UnityAction observer)
        {
            _view.UnsubscribeFromAcceptButton(observer);
        }


        public void SubscribeToDeclineButton(UnityAction observer)
        {
            _view.SubscribeToDeclineButton(observer);
        }

        public void UnsubscribeFromDeclineButton(UnityAction observer)
        {
            _view.UnsubscribeFromDeclineButton(observer);
        }


        public void UserAcceptPrivacyPolicy()
        {
            _model.UserAcceptPrivacyPolicy();
        }

        public bool IsAcceptAgreement()
        {
            return _model.IsAcceptedAgreement;
        }


        void IDisposable.Dispose()
        {
            UnsubscribeFromTermsAndConditionsButton();
            UnsubscribeFromPrivacyPolicyButton();
        }


        private void AddObserversToView()
        {
            SubscribeToTermsAndConditionsButton();
            SubscribeToPrivacyPolicyButton();
        }

        private void SubscribeToTermsAndConditionsButton()
        {
            _view.SubscribeToTermsAndConditionsButton(_model.OpenTermsAndConditionsURL);
        }

        private void UnsubscribeFromTermsAndConditionsButton()
        {
            _view.UnsubscribeFromTermsAndConditionsButton(_model.OpenTermsAndConditionsURL);
        }


        private void SubscribeToPrivacyPolicyButton()
        {
            _view.SubscribeToPrivacyPolicyButton(_model.OpenPrivacyPolicyURL);
        }

        private void UnsubscribeFromPrivacyPolicyButton()
        {
            _view.UnsubscribeFromPrivacyPolicyButton(_model.OpenPrivacyPolicyURL);
        }
    }
}