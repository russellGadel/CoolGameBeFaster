using System;

namespace Core.BootstrapExecutor
{
    public interface IBootstrapExecutor
    {
        void Add(IBootstrapper bootstrap);
        void Execute();
        bool IsDone();
        void Clear();
        void SubscribeToEndBootstrapEvent(Action observer);
        void UnsubscribeFromEndBootstrapEvent(Action observer);
    }
}