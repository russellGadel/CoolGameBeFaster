using UnityEngine.Events;

namespace CustomUI.UpdateGame
{
    public interface IUpdateGameView
    {
        void Open();
        void Close();

        void SubscribeToPressUpdateButton(UnityAction observer);
        void UnsubscribeFromPressUpdateButton(UnityAction observer);
    }
}