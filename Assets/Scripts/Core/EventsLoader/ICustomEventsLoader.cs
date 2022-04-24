namespace Core.EventsLoader
{
    public interface ICustomEventsLoader
    {
        void AddEvent(ICustomEventLoader customEventLoader);
        void Load();
        void Clear();
    }
}