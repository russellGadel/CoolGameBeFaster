using System.Collections;

namespace Core.CustomCoroutine
{
    public interface ICustomCoroutineClient
    {
        IEnumerator CoroutineForExecute();
    }
}