using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Core
{
    public class DataHandler<T>
    {
        protected void Save(T savingData, string fileName)
        {
            string path = Path.Combine(Application.persistentDataPath + "/" + fileName);

            BinaryFormatter bfFlow = new BinaryFormatter();

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            using FileStream saveFile = File.Create(path);
            bfFlow.Serialize(saveFile, savingData);
        }

        protected void Load(ref T savedGameData, string fileName)
        {
            string path = Path.Combine(Application.persistentDataPath + "/" + fileName);

            if (File.Exists(path))
            {
                BinaryFormatter bfFlowAutomatically = new BinaryFormatter();
                using FileStream automaticallySaveFile = File.Open(path, FileMode.Open);

                savedGameData = (T) bfFlowAutomatically.Deserialize(automaticallySaveFile);
            }
        }
    }
}