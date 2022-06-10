using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.EventsLoader
{
    public sealed class CustomEventsLoader : MonoBehaviour
        , ICustomEventsLoader
    {
        private readonly List<ICustomEventLoader> _events = new List<ICustomEventLoader>();

        public void AddEvent(in ICustomEventLoader customEventLoader)
        {
            _events.Add(customEventLoader);
        }

        public void Load()
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
                yield return StartCoroutine(_events[i].Load());
            }

            _isDone = true;
        }
    }
}