using TMPro;
using UnityEngine;

namespace CustomUI.Points
{
    public sealed class PlayerPointsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _pointsTable;

        public void UpdatePoints(double value)
        {
            _pointsTable.SetText(value.ToString());
        }
    }
}