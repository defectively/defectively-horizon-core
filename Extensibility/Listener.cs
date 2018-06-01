namespace Defectively.Core.Extensibility
{
    public class Listener
    {
        public EventType EventType { get; set; }
        public Extension Extension { get; set; }

        public Listener(EventType eventType, Extension extension) {
            EventType = eventType;
            Extension = extension;
        }
    }
}
