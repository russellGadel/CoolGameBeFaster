using ECS.References.Camera;
using Services.Game;
using Services.Player;
using UnityEngine;

namespace ECS.References.MainScene
{
    public class MainSceneData : MonoBehaviour
    {
        public GameSettings gameSettings;
        public InterferingObjectsAppearingPositionSettings interferingObjectsAppearingPositionSettings;
        public PlayerCustomSettings playerSettings;
    }
}