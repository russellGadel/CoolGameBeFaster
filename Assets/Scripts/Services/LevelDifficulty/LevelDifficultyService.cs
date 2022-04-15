namespace Services.LevelDifficulty
{
    public sealed class LevelDifficultyService : ILevelDifficultyService
    {
        private readonly LevelDifficultySettings _settings;

        public LevelDifficultyService(LevelDifficultySettings settings)
        {
            _settings = settings;
        }

        private int _lastDifficultyIndex = 0;

        public LevelDifficulty GetDifficulty(double spawnedPointersAmount)
        {
            if (_settings.settings[_lastDifficultyIndex].spawnedPointsAmount < spawnedPointersAmount)
            {
                IncreaseLastDifficultyIndex();
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