using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.BootstrapExecutor
{
    public class BootstrapExecutor : MonoBehaviour
        , IBootstrapExecutor
    {
        private readonly List<IBootstrapper> _events = new List<IBootstrapper>();

        public void Add(IBootstrapper bootstrap)
        {
            _events.Add(bootstrap);
        }

        public void Execute()
        {
            StartCoroutine(ExecuteCoroutine());
        }

        public void Clear()
        {
            _events.Clear();
            _isDone = false;
        }

        private bool _isDone = false;

        public bool IsDone()
        {
            return _isDone;
        }

        private delegate void Observers();

        private event Observers _thenEndLoading;

        public void AddObserverToEndBootstrapEvent(Action observer)
        {
            _thenEndLoading += () => observer();
        }

        private IEnumerator ExecuteCoroutine()
        {
            for (int i = 0; i < _events.Count; i++)
            {
                yield return StartCoroutine(_events[i].Execute());
            }

            _isDone = true;
            _thenEndLoading?.Invoke();
        }
    }
}