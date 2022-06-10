using System;

namespace Core.CustomInvoker
{
    public interface ICustomInvokerService
    {
        void CustomInvoke(Action action, in float delayTime);
    }
}