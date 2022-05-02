using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.CustomInvoker
{
    public class CustomInvokerService : MonoBehaviour, ICustomInvokerServiceForInvokers
        , ICustomInvokerService
    {
        private readonly List<CustomInvoker> _freeInvokers = new List<CustomInvoker>();

        public void CustomInvoke(Action action, float delayTime)
        {
            if (_freeInvokers.Count != 0)
            {
                CustomInvoker customInvoker = _freeInvokers.First();
                _freeInvokers.Remove(customInvoker);

                customInvoker.CustomInvoke(action, delayTime);
            }
            else
            {
                CustomInvoker customInvoker = CreateNewCustomInvoker();
                customInvoker.CustomInvoke(action, delayTime);
            }
        }

        void ICustomInvokerServiceForInvokers.AddFreeInvoker(ref CustomInvoker invoker)
        {
            _freeInvokers.Add(invoker);
        }

        private CustomInvoker CreateNewCustomInvoker()
        {
            CustomInvoker customInvoker = gameObject.AddComponent<CustomInvoker>();
            customInvoker.Construct(this);

            return customInvoker;
        }
    }
}