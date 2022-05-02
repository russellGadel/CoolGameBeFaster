using Core.CustomInvoker;
using ScenesBootstrapper.MainScene.Events;
using Services.GameTime;
using Services.LevelDifficulty;
using Services.SaveData;
using UnityEngine;
using Zenject;

namespace ECS.References.MainScene
{
    public class MainSceneServices : MonoBehaviour
    {
        [Inject] public ILevelDifficultyService LevelDifficultyService;
        [Inject] public IGameTimeService GameTimeService;
        [Inject] public MainSceneEventsService MainSceneEventsService;
        [Inject] public ISaveDataService SaveDataService;
        [Inject] public ICustomInvokerService CustomInvokerService;
    }
}