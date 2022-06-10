namespace Core.CustomCoroutine
{
    public interface IServiceForCustomCoroutine
    {
        void AddFreeCoroutine(in CustomCoroutine coroutine);
    }
}