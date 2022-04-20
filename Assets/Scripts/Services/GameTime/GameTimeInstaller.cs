using Zenject;

namespace Services.GameTime
{
    public class GameTimeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IGameTimeService>()
                .FromInstance(new GameTimeService())
                .AsSingle();
        }
    }
}