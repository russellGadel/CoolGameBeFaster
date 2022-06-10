namespace Core.EventsLoader
{
    public interface ICustomEventsLoader
    {
        void AddEvent(in ICustomEventLoader customEventLoader);
        void Load();
        void Clear();
    }
}