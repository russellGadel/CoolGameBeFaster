using System.Collections;

namespace Core.EventsLoader
{
    public interface ICustomEventLoader
    {
        IEnumerator Load();
    }
}