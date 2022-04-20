using Services.GameTime;
using Services.LevelDifficulty;
using UnityEngine;
using Zenject;

namespace ECS.References.MainScene
{
    public class MainSceneServices : MonoBehaviour
    {
        [Inject] public ILevelDifficultyService LevelDifficultyService;
        [Inject] public IGameTimeService GameTimeService;
    }
}