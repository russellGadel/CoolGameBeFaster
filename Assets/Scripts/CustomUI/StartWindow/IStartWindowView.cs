using System;
using Core.InstallersExecutor;
using UnityEngine.Events;

namespace CustomUI.StartWindow
{
    public interface IStartWindowView : ICustomInstaller
    {
        void Open();
        void Close();

        void SubscribeToPressStartGameButton(UnityAction observer);
        void UnsubscribeFromPressStartGameButton(UnityAction observer);

        void SubscribeToFirstPressOnReferencesListButton(Action observer);
        void UnsubscribeFromFirstPressOnReferencesListButton(Action observer);

        void SubscribeToSecondPressOnReferencesListButton(Action observer);
        void UnsubscribeFromSecondPressOnReferencesListButton(Action observer);

        void SetMaxPoints(string maxPoints);
    }
}