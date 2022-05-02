using System;
using UnityEngine;

namespace Core.CustomInvoker
{
    public class CustomInvoker : MonoBehaviour
    {
        private CustomInvoker _invoker;
        private ICustomInvokerServiceForInvokers _customInvokerService;

        public void Construct(ICustomInvokerServiceForInvokers customInvokerService)
        {
            _invoker = this;
            _customInvokerService = customInvokerService;
        }


        private delegate void Function();

        private event Function _function = null;

        public void CustomInvoke(Action action, float delayTime)
        {
            _function = () => action();
            Invoke(nameof(InvokeFunction), delayTime);
        }

        private void InvokeFunction()
        {
            _function.Invoke();
            _customInvokerService.AddFreeInvoker(ref _invoker);
        }
    }
}