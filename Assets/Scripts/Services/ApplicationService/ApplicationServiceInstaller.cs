using Zenject;

namespace Services.ApplicationService
{
    public class ApplicationServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IApplicationService>()
                .To<ApplicationService>()
                .AsSingle();
        }
    }
}