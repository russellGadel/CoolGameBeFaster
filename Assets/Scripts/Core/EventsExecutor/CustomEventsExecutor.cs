using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EventsExecutor
{
    public class CustomEventsExecutor : MonoBehaviour, ICustomEventsExecutor
    {
        private readonly List<ICustomEvent> _events = new List<ICustomEvent>();

        public void AddEvent(ICustomEvent customEvent)
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
                yield return StartCoroutine(_events[i].Execute());
            }

            _isDone = true;
        }
    }
}