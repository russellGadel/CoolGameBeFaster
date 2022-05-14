using System;
using Core;
using UnityEngine;

namespace Services.SaveData
{
    public class SaveDataService : DataHandler<SaveData>
        , ISaveDataService
        , ISaveDataServiceForEvents
    {
        private SaveData _data = new SaveData();
        private const string SaveFileName = "saveData.ggsSave";

        public void Save()
        {
            _saveObservers?.Invoke();
            base.Save(_data, SaveFileName);
            Debug.Log("Saved data");
        }

        private delegate void Observer();

        private event Observer _saveObservers = null;

        public void AddSaveEventObservers(Action observer)
        {
            _saveObservers += () => observer();
        }

        public void Load()
        {
            base.Load(ref _data, SaveFileName);
            Debug.Log("LoadData");
        }
        
        public ref SaveData GetData()
        {
            return ref _data;
        }
    }
}