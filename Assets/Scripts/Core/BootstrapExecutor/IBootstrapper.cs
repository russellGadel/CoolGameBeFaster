using System.Collections;

namespace Core.BootstrapExecutor
{
    public interface IBootstrapper
    {
        IEnumerator Execute();
    }
}