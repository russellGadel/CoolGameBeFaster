using CustomUI.Points;
using UnityEngine;
using Zenject;

namespace CustomUI
{
    public class MainSceneUIViews : MonoBehaviour
    {
        [Inject] public IPlayerPointsViewsGroup PlayerPointsViewsGroup;
    }
}