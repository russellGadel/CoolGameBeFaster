using System;
using CustomUI.InternetConnection;
using JetBrains.Annotations;
using UnityEngine;

namespace Services.InternetConnection
{
    public class InternetConnectionPresenter : MonoBehaviour
        , IInternetConnectionService
    {
        private IInternetConnectionModel _model;
        private IHasNotInternetConnectionView _hasNotConnectionView;

        public void Construct(IInternetConnectionModel model
            , IHasNotInternetConnectionView hasNotConnectionView)
        {
            _model = model;
            _hasNotConnectionView = hasNotConnectionView;
        }

        public void CheckInternetConnection([CanBeNull] Action thenHasInternetConnection,
            [CanBeNull] Action thenHasNotInternetConnection)
        {
            void HasInternetConnectionObservers()
            {
                _hasNotConnectionView.Close();
                thenHasInternetConnection?.Invoke();
            }

            _model
                .AddOnlyOneObserverToHasInternetConnectionEvent(HasInternetConnectionObservers);


            void HasNotInternetConnectionObservers()
            {
                _hasNotConnectionView.Open();
                StartCoroutine(_model.CheckInternetConnectionWithDelay());
                thenHasNotInternetConnection?.Invoke();
            }

            _model.AddOnlyOneObserverToHasNotInternetConnectionEvent(
                HasNotInternetConnectionObservers);


            StartCoroutine(_model.CheckInternetConnection());
        }
    }
}