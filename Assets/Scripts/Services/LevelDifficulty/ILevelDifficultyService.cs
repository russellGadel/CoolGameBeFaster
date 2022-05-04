namespace Services.LevelDifficulty
{
    public interface ILevelDifficultyService
    {
        LevelDifficulty GetDifficulty(double spawnedPointsAmount);
    }
}