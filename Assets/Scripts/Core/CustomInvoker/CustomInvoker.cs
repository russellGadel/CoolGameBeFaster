using System;
using UnityEngine;

namespace Core.CustomInvoker
{
    public sealed class CustomInvoker : MonoBehaviour
    {
        private CustomInvoker _invoker;
        private ICustomInvokerServiceForInvokers _customInvokerService;

        public void Construct(in ICustomInvokerServiceForInvokers customInvokerService)
        {
            _invoker = this;
            _customInvokerService = customInvokerService;
        }

        
        private event Action _function = null;

        public void CustomInvoke(Action action, in float delayTime)
        {
            _function = action;
            Invoke(nameof(InvokeFunction), delayTime);
        }

        private void InvokeFunction()
        {
            _function.Invoke();
            _customInvokerService.AddFreeInvoker(in _invoker);
        }
    }
}