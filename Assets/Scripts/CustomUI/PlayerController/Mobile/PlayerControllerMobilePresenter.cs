using UnityEngine;

namespace CustomUI.PlayerController.Mobile
{
    public sealed class PlayerControllerMobilePresenter :
        IPlayerControllerPresenter
    {
        private readonly IPlayerControllerMobileView _mobileView;

        public PlayerControllerMobilePresenter(IPlayerControllerMobileView mobileView)
        {
            _mobileView = mobileView;
        }

        public Vector2 GetInputVector()
        {
            return _mobileView.GetInputVector();
        }
    }
}