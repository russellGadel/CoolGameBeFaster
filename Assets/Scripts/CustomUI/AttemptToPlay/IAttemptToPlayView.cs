using System;
using Core.InstallersExecutor;
using UnityEngine.Events;

namespace CustomUI.AttemptToPlay
{
    public interface IAttemptToPlayView : ICustomInstaller
    {
        void Open();
        void Close();

        void SubscribeToRepeatButton(UnityAction observer);
        void UnsubscribeFromRepeatButton(UnityAction observer);

        void SubscribeToAdvertisingButton(UnityAction observer);
        void UnsubscribeFromAdvertisingButton(UnityAction observer);


        void SetCurrentPointsAmount(in double points);
        void SetMaxPointsAmount(in double points);
        void SetAdvertisementButtonInteractableValue(in bool value);
    }
}