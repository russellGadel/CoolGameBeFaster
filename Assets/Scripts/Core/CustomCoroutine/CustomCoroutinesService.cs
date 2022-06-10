using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.CustomCoroutine
{
    public sealed class CustomCoroutinesService : MonoBehaviour
        , ICustomCoroutinesService
        , IServiceForCustomCoroutine
    {
        private readonly List<CustomCoroutine> _freeCoroutines = new List<CustomCoroutine>();

        public void StartCustomCoroutine(in ICustomCoroutineClient customCoroutineClient)
        {
            CustomCoroutine customCoroutine;

            if (_freeCoroutines.Count != 0)
            {
                customCoroutine = _freeCoroutines.First();
                _freeCoroutines.Remove(customCoroutine);
            }
            else
            {
                customCoroutine = CreateNewCustomCoroutine();
            }

            customCoroutine.StartCustomCoroutine(customCoroutineClient);
        }

        void IServiceForCustomCoroutine.AddFreeCoroutine(in CustomCoroutine coroutine)
        {
            _freeCoroutines.Add(coroutine);
        }


        private CustomCoroutine CreateNewCustomCoroutine()
        {
            CustomCoroutine coroutine = gameObject.AddComponent<CustomCoroutine>();
            coroutine.Construct(this);
            return coroutine;
        }
    }
}