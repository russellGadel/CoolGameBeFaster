namespace Core.BootstrapExecutor
{
    public interface IBootstrapExecutor
    {
        void Add(IBootstrapper bootstrap);
        void Execute();
        bool IsDone();
        void Clear();
    }
}