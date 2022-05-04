using UnityEngine;

namespace CustomUI.PlayerController
{
    public interface IPlayerControllerPresenter
    {
        void OpenView();
        void CloseView();
        Vector2 GetInputVector();
    }
}