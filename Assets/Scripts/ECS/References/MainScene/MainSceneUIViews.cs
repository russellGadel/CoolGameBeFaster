using CustomUI.AttemptToPlay;
using CustomUI.Points;
using UnityEngine;
using Zenject;

namespace ECS.References.MainScene
{
    public class MainSceneUIViews : MonoBehaviour
    {
        [Inject] public IPlayerPointsViewsGroup PlayerPointsViewsGroup;
    }
}