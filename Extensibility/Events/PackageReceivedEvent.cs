using Defectively.Core.Communication;

namespace Defectively.Core.Extensibility.Events
{
    public class PackageReceivedEvent : Event
    {
        public Package Package { get; set; }
    }
}
