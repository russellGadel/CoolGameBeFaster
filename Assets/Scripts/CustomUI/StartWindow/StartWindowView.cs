using System;
using System.Collections;
using CustomUI.DualButton;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CustomUI.StartWindow
{
    public sealed class StartWindowView : MonoBehaviour
        , IStartWindowView
    {
        public IEnumerator Install()
        {
            _referencesListDualButton.Construct();
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


        [SerializeField] private Button _startGameButton;

        public void AddObserversToPressStartGameButton(Action observer)
        {
            _startGameButton.onClick.AddListener(() => observer());
        }


        [SerializeField] private DualButtonView _referencesListDualButton;

        public void AddObserversToFirstPressOnReferencesListButton(Action observer)
        {
            _referencesListDualButton.AddObserverToFirstKeyStroke(observer);
        }

        public void AddObserversToSecondPressOnReferencesListButton(Action observer)
        {
            _referencesListDualButton.AddObserverToSecondKeyStroke(observer);
        }

        [SerializeField] private TextMeshProUGUI _maxPointsTable;


        public void SetMaxPoints(string maxPoints)
        {
            _maxPointsTable.SetText(maxPoints);
        }
    }
}