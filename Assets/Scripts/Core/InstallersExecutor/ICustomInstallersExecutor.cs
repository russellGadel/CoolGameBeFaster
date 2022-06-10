namespace Core.InstallersExecutor
{
    public interface ICustomInstallersExecutor
    {
        void AddInstaller(in ICustomInstaller customEvent);
        void Execute();
        void Clear();
        bool IsDone();
    }
}