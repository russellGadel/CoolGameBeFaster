using ECS.Components.LevelDifficultyComponent;

namespace Services.LevelDifficulty
{
    public interface ILevelDifficultyService
    {
        LevelDifficulty GetDifficulty(double spawnedPointersAmount);
    }
}