using UnityEngine;

namespace CustomUI.PlayerController.PC
{
    public class PlayerControllerPCPresenter : IPlayerControllerPresenter
    {
        private Vector2 _inputVector;

        public void OpenView()
        {
            //
        }

        public void CloseView()
        {
            //
        }

        public Vector2 GetInputVector()
        {
            _inputVector.x = Input.GetAxis("Horizontal");
            _inputVector.y = Input.GetAxis("Vertical");

            if (_inputVector.magnitude > 1)
            {
                _inputVector.Normalize();
            }

            return _inputVector;
        }
    }
}