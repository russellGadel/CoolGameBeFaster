using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.BootstrapExecutor
{
    public sealed class BootstrapExecutor : MonoBehaviour
        , IBootstrapExecutor
    {
        private readonly List<IBootstrapper> _events = new List<IBootstrapper>();

        public void Add(in IBootstrapper bootstrap)
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
        
        private event Action ThenEndLoading;

        public void SubscribeToEndBootstrapEvent(Action observer)
        {
            ThenEndLoading += observer;
        }

        public void UnsubscribeFromEndBootstrapEvent(Action observer)
        {
            ThenEndLoading -= observer;
        }

        private IEnumerator ExecuteCoroutine()
        {
            for (int i = 0; i < _events.Count; i++)
            {
                yield return StartCoroutine(_events[i].Execute());
            }

            _isDone = true;
            ThenEndLoading?.Invoke();
        }
    }
}