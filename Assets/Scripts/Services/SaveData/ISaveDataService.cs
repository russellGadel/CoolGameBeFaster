using System;

namespace Services.SaveData
{
    public interface ISaveDataService
    {
        void SubscribeToSaveEvent(Action observer);
        void UnsubscribeFromSaveEvent(Action observer);
        ref SaveData GetData();
    }
}