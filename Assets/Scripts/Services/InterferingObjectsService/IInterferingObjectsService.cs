using ECS.Components.EntityReference;
using ECS.Components.LevelDifficulty;

namespace Services.InterferingObjectsService
{
    public interface IInterferingObjectsService
    {
        MonoEntity GetInterferingObject(in LevelDifficultyNaming currentLevelDifficulty);
    }
}