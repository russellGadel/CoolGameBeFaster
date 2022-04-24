using System;
using Core;

namespace Services.SaveData
{
    public class SaveDataService : DataHandler<SaveData>, ISaveDataService
    {
        private SaveData _data = new SaveData();
        private const string SaveFileName = "saveData.ggsSave";

        public void Save()
        {
            _saveObservers?.Invoke(ref _data);
            base.Save(_data, SaveFileName);
        }

        private delegate void Observer(ref SaveData saveData);

        private event Observer _saveObservers = null;

        public void AddSaveEventObservers(Action<SaveData> observer)
        {
            _saveObservers += (ref SaveData data) => observer(_data);
        }


        public void Load()
        {
            base.Load(ref _data, SaveFileName);
            loadObservers?.Invoke(ref _data);
        }

        private event Observer loadObservers = null;

        public void AddLoadEventObservers(Action<SaveData> observer)
        {
            loadObservers += (ref SaveData data) => observer(_data);
        }
    }
}