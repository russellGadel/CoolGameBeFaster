using UnityEngine;
using Zenject;

namespace Services.LevelDifficulty
{
    public sealed class LevelDifficultyServiceInstaller : MonoInstaller
    {
        [SerializeField] private LevelDifficultySettings _settings;
        
        public override void InstallBindings()
        {
            BindService();
        }

        private void BindService()
        {
            Container
                .Bind<ILevelDifficultyService>()
                .To<LevelDifficultyService>()
                .FromMethod(InstallService)
                .AsSingle();
        }

        private LevelDifficultyService InstallService()
        {
            return new LevelDifficultyService(_settings);
        }
    }
}