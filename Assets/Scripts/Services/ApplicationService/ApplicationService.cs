using UnityEngine;

namespace Services.ApplicationService
{
    public class ApplicationService : IApplicationService
    {
        public void Quit()
        {
            Application.Quit();
        }
    }
}