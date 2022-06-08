namespace CustomUI.LoadingWindow
{
    public interface ILoadingWindowView
    {
        void Open();
        void Close();
        void SetGameVersion(in string gameVersion);
    }
}