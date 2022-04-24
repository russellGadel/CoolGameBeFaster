using System;

namespace Services.SaveData
{
    public interface ISaveDataService
    {
        void AddSaveEventObservers(Action observer);
        ref SaveData GetData();
    }
}