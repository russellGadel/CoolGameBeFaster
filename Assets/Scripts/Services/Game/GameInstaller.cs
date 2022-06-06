using UnityEngine;
using Zenject;

namespace Services.Game
{
    public sealed class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameSettings _settings;

        public override void InstallBindings()
        {
            Container
                .Bind<GameSettings>()
                .FromInstance(_settings)
                .AsSingle();
        }
    }
}