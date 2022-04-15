using ECS.Data.Camera;
using Services.LevelDifficulty;
using UnityEngine;
using Zenject;

namespace ECS.Data
{
    public class MainSceneData : MonoBehaviour
    {
        public InterferingObjectsAppearingPositionData interferingObjectsAppearingPositionData;
        [Inject] public ILevelDifficultyService LevelDifficultyService;
    }
}