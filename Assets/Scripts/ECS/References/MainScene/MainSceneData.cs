using ECS.References.Camera;
using Services.GamePlay;
using Services.Player;
using UnityEngine;

namespace ECS.References.MainScene
{
    public class MainSceneData : MonoBehaviour
    {
        public GamePlaySettings gamePlaySettings;
        public InterferingObjectsAppearingPositionSettings interferingObjectsAppearingPositionSettings;
        public PlayerCustomSettings playerSettings;
    }
}