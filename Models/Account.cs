using Defectively.Core.Storage;

namespace Defectively.Core.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public AresStorage AresFlags { get; set; }
        public byte[] Password { get; set; }
        public string TeamId { get; set; }
    }
}
