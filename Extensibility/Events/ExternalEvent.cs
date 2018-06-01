using Defectively.Core.Communication;
using Newtonsoft.Json;

namespace Defectively.Core.Extensibility.Events
{
    public class ExternalEvent : Event
    {
        public string EventName { get; set; }
        public string Invoker { get; set; }
        public object[] Parameters { get; set; }

        public ExternalEvent() { }

        public ExternalEvent(string name) {
            this.EventName = name;
        }

        public ExternalEvent(string name, params object[] @params) : this(name) {
            this.Parameters = @params;
        }

        public TOut GetParameter<TOut>(int index) {
            return JsonConvert.DeserializeObject<TOut>(JsonConvert.SerializeObject(Parameters[index]));
        }

        public Package ToPackage() => new Package(PackageType.ExternalEvent, this);
    }
}
