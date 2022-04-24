namespace Services.SaveData
{
    public interface ISavedDataReader
    {
        void Load(ref SaveData saveData);
    }
}