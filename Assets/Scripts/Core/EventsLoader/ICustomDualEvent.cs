namespace Core.EventsLoader
{
    public interface ICustomDualEvent
    {
        void Execute();
        void Undo();
    }
}