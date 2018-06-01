using Newtonsoft.Json;

namespace Defectively.Core.Communication
{
    public class Package
    {
        public PackageType Type { get; set; }
        public object[] Content { get; set; }
        
        public Package(PackageType type, params object[] content) {
            Type = type;
            Content = content;
        }

        public TOut GetContent<TOut>(int index = 0) {
            return JsonConvert.DeserializeObject<TOut>(JsonConvert.SerializeObject(Content[index]));
        } 
    }

    public enum PackageType
    {
        Assembly,
        Authentication,
        Debug,
        Development,
        ExternalEvent,
        Error,
        Information,
        Success,
        Warning
    }
}
