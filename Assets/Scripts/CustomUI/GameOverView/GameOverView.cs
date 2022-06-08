using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.GameOverView
{
    public sealed class GameOverView : MonoBehaviour
        , IGameOverView
    {
        [SerializeField] private Button _repeatButton;

        public IEnumerator Install()
        {
            _repeatButton.onClick.RemoveAllListeners();
            yield return null;
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void SubscribeToRepeatButton(Action observer)
        {
            _repeatButton.onClick.AddListener(() => observer());
        }

        [SerializeField] private TextMeshProUGUI _currentPointsText;

        public void SetCurrentPointsAmount(in double points)
        {
            _currentPointsText.SetText(points.ToString(CultureInfo.InvariantCulture));
        }


        [SerializeField] private TextMeshProUGUI _maxPointsText;

        public void SetMaxPointsAmount(in double points)
        {
            _maxPointsText.SetText(points.ToString(CultureInfo.InvariantCulture));
        }
    }
}