using Core.InstallersExecutor;
using UnityEngine.Events;

namespace CustomUI.GameOverView
{
    public interface IGameOverView : ICustomInstaller
    {
        void Open();
        void Close();

        void SubscribeToRepeatButton(UnityAction observer);
        void UnsubscribeFromRepeatButton(UnityAction observer);

        void SetCurrentPointsAmount(in double points);
        void SetMaxPointsAmount(in double points);
    }
}