using UnityEngine;

namespace CustomUI.Points
{
    public sealed class PlayerPointsViewsGroup : MonoBehaviour
        , IPlayerPointsViewsGroup
    {
        [SerializeField] private PlayerPointsView _playerPointsView;

        public void UpdatePoints(in double value)
        {
            _playerPointsView.UpdatePoints(in value);
        }
    }
}