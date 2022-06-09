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

        public void Construct(in IInternetConnectionModel model
            , in IHasNotInternetConnectionView hasNotConnectionView)
        {
            _model = model;
            _hasNotConnectionView = hasNotConnectionView;
        }

        public void CheckInternetConnection([CanBeNull] Action thenHasInternetConnection,
            [CanBeNull] Action thenHasNotInternetConnection)
        {
            _model.AddOnlyOneObserverToHasInternetConnectionEvent(() =>
                HasInternetConnectionObservers(thenHasInternetConnection));


            _model.AddOnlyOneObserverToHasNotInternetConnectionEvent(() =>
                HasNotInternetConnectionObservers(thenHasNotInternetConnection));


            StartCoroutine(_model.CheckInternetConnection());
        }

        private void HasInternetConnectionObservers(in Action thenHasInternetConnection)
        {
            _hasNotConnectionView.Close();
            thenHasInternetConnection?.Invoke();
        }

        private void HasNotInternetConnectionObservers(in Action thenHasNotInternetConnection)
        {
            _hasNotConnectionView.Open();
            StartCoroutine(_model.CheckInternetConnectionWithDelay());
            thenHasNotInternetConnection?.Invoke();
        }
    }
}