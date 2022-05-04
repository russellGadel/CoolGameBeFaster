using UnityEngine;

namespace CustomUI.PlayerController.Mobile
{
    public interface IPlayerControllerMobileView
    {
        void Open();
        void Close();
        Vector2 GetInputVector();
    }
}