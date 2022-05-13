using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.StartWindow
{
    public sealed class StartWindowView : MonoBehaviour, IStartWindowView
    {
        public void Load()
        {
            LoadStartGameButton();
        }

        public void Open()
        {
            gameObject.SetActive(true);
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }

        [SerializeField] private Button _startGameButton;

        public void AddObserversToPressStartGameButton(Action observer)
        {
            _startGameButton.onClick.AddListener(() => observer());
        }

        
        [SerializeField] private TextMeshProUGUI _maxPointsTable;
        public void SetMaxPoints(string maxPoints)
        {
            _maxPointsTable.SetText(maxPoints);
        }


        private void LoadStartGameButton()
        {
            _startGameButton.onClick.RemoveAllListeners();
        }
    }
}