namespace Core.InstallersExecutor
{
    public interface ICustomInstallersExecutor
    {
        void AddInstaller(ICustomInstaller customEvent);
        void Execute();
        void Clear();
        bool IsDone();
    }
}