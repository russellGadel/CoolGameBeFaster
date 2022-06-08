using UnityEngine;

namespace CustomUI.PlayerController.Mobile
{
    public sealed class PlayerControllerMobilePresenter :
        IPlayerControllerPresenter
    {
        private readonly IPlayerControllerMobileView _mobileView;

        public PlayerControllerMobilePresenter(in IPlayerControllerMobileView mobileView)
        {
            _mobileView = mobileView;
        }

        public void OpenView()
        {
            _mobileView.Open();
        }

        public void CloseView()
        {
            _mobileView.Close();
        }

        public Vector2 GetInputVector()
        {
            return _mobileView.GetInputVector();
        }
    }
}