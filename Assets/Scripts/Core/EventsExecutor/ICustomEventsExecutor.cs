namespace Core.EventsExecutor
{
    public interface ICustomEventsExecutor
    {
        void AddEvent(ICustomEvent customEvent);
        void Execute();
        void Clear();
    }
}