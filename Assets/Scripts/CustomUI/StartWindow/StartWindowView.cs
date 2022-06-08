using System;
using System.Collections;
using CustomUI.DualButton;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
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

        public void SubscribeToPressStartGameButton(UnityAction observer)
        {
            _startGameButton.onClick.AddListener(observer);
        }

        public void UnsubscribeFromPressStartGameButton(UnityAction observer)
        {
            _startGameButton.onClick.RemoveListener(observer);
        }


        [SerializeField] private DualButtonView _referencesListDualButton;

        public void SubscribeToFirstPressOnReferencesListButton(Action observer)
        {
            _referencesListDualButton.FirstKeyStrokeEvent += observer;
        }

        public void UnsubscribeFromFirstPressOnReferencesListButton(Action observer)
        {
            _referencesListDualButton.FirstKeyStrokeEvent -= observer;
        }


        public void SubscribeToSecondPressOnReferencesListButton(Action observer)
        {
            _referencesListDualButton.SecondKeyStrokeEvent += observer;
        }

        public void UnsubscribeFromSecondPressOnReferencesListButton(Action observer)
        {
            _referencesListDualButton.SecondKeyStrokeEvent -= observer;
        }

        [SerializeField] private TextMeshProUGUI _maxPointsTable;


        public void SetMaxPoints(in string maxPoints)
        {
            _maxPointsTable.SetText(maxPoints);
        }
    }
}