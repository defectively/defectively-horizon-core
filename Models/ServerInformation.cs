using System.Collections.Generic;

namespace Defectively.Core.Models
{
    public class ServerInformation
    {
        public string Name { get; set; }
        public bool AcceptsClients { get; set; }
        public IEnumerable<string> Extensions { get; set; } = new List<string>();
        public IEnumerable<string> ClientExtensions { get; set; } = new List<string>();
        public string Url { get; set; }
    }
}
