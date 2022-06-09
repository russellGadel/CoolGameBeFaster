namespace Services.LevelDifficulty
{
    public interface ILevelDifficultyService
    {
        LevelDifficulty GetDifficulty(in double spawnedPointsAmount);
    }
}