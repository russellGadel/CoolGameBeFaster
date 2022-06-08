using UnityEngine.Events;

namespace CustomUI.UpdateGame
{
    public interface IUpdateGamePresenter
    {
        void OpenView();
        void CloseView();

        void SubscribeToUpdateButton(UnityAction observer);
        void UnsubscribeFromPressUpdateButton(UnityAction observer);

        void GoToAppStore();
    }
}