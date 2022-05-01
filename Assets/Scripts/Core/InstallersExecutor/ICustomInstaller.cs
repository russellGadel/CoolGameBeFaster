using System.Collections;

namespace Core.InstallersExecutor
{
    public interface ICustomInstaller
    {
        IEnumerator Install();
    }
}