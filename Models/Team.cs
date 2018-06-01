using System.Collections.Generic;
using Defectively.Core.Storage;

namespace Defectively.Core.Models
{
    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AresStorage AresFlags { get; set; }
        public List<string> Members { get; set; } = new List<string>();
        public string Tag { get; set; }
        public string Color { get; set; }
    }
}
