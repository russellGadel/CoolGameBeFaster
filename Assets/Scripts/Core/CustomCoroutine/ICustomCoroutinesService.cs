namespace Core.CustomCoroutine
{
    public interface ICustomCoroutinesService
    {
        void StartCustomCoroutine(in ICustomCoroutineClient customCoroutineClient);
    }
}