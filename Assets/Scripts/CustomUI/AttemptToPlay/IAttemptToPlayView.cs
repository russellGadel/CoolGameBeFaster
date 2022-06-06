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
        void UnsubscribeToAdvertisingButton(UnityAction observer);


        void SetCurrentPointsAmount(double points);
        void SetMaxPointsAmount(double points);
        void SetAdvertisementButtonInteractableValue(bool value);
    }
}