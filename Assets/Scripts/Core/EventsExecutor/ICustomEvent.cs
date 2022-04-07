using System.Collections;

namespace Core.EventsExecutor
{
    public interface ICustomEvent
    {
        IEnumerator Execute();
    }
}