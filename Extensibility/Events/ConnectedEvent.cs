using Defectively.Core.Networking;

namespace Defectively.Core.Extensibility.Events
{
    public class ConnectedEvent : Event
    {
        public Client Client { get; set; }
    }
}
