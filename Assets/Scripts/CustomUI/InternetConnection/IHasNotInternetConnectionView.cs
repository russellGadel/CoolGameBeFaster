namespace CustomUI.InternetConnection
{
    public interface IHasNotInternetConnectionView
    {
        void Open();
        void Close();
        void ShowWithBlinking();
        void StopAnyActions();
    }
}