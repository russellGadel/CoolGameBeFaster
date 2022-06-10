using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.InstallersExecutor
{
    public sealed class CustomInstallersExecutor : MonoBehaviour
        , ICustomInstallersExecutor
    {
        private readonly List<ICustomInstaller> _events = new List<ICustomInstaller>();

        public void AddInstaller(in ICustomInstaller customEvent)
        {
            _events.Add(customEvent);
        }

        public void Execute()
        {
            StartCoroutine(ExecuteCoroutine());
        }

        public void Clear()
        {
            _isDone = false;
            _events.Clear();
        }

        private bool _isDone = false;

        public bool IsDone()
        {
            return _isDone;
        }

        private IEnumerator ExecuteCoroutine()
        {
            for (int i = 0; i < _events.Count; i++)
            {
                yield return StartCoroutine(_events[i].Install());
            }

            _isDone = true;
        }
    }
}