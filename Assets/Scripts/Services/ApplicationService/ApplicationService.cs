namespace Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        public void Quit()
        {
            UnityEngine.Application.Quit();
        }
    }
}