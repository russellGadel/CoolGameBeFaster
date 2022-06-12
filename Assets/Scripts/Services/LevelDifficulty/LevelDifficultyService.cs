using ECS.Components.LevelDifficulty;

namespace Services.LevelDifficulty
{
    public sealed class LevelDifficultyService : ILevelDifficultyService
    {
        private readonly LevelDifficultySettings _settings;

        public LevelDifficultyService(in LevelDifficultySettings settings)
        {
            _settings = settings;
        }

        private const int FirstDifficultyIndex = 0;
        private int _lastDifficultyIndex = FirstDifficultyIndex;

        public LevelDifficulty GetDifficulty(in double spawnedPointsAmount)
        {
            if (spawnedPointsAmount > _settings.settings[_lastDifficultyIndex].spawnedPointsAmount)
            {
                IncreaseLastDifficultyIndex();
            }
            else
            {
                if (spawnedPointsAmount == 0)
                {
                    _lastDifficultyIndex = FirstDifficultyIndex;
                }
            }

            return _settings.settings[_lastDifficultyIndex];
        }


        private void IncreaseLastDifficultyIndex()
        {
            int futureValue = _lastDifficultyIndex + 1;

            if (futureValue < _settings.settings.Length)
            {
                _lastDifficultyIndex = futureValue;
            }
        }
    }
}