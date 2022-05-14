namespace Core.CustomCoroutine
{
    public interface ICustomCoroutinesService
    {
        void StartCustomCoroutine(ICustomCoroutineClient customCoroutineClient);
    }
}