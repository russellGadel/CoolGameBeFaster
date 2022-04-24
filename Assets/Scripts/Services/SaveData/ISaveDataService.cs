using System;

namespace Services.SaveData
{
    public interface ISaveDataService
    {
        void Save();
        void AddSaveEventObservers(Action<SaveData> observer);
        void Load();
        void AddLoadEventObservers(Action<SaveData> observer);
    }
}