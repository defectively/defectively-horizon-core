namespace Defectively.Core.Extensibility
{
    public abstract class Event
    {
        public string EndpointId { get; set; }
        public bool SkipLegacyHandling { get; set; }
    }

    public enum EventType
    {
        External,
        PackageReceived,
        InputReceived,
        Connected,
        Authenticated
    }
}
