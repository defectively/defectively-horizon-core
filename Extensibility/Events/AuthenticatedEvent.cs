using Defectively.Core.Models;

namespace Defectively.Core.Extensibility.Events
{
    public class AuthenticatedEvent : Event
    {
        public Account Account { get; set; }
    }
}