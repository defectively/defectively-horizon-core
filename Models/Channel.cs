using System.Collections.Generic;

namespace Defectively.Core.Models
{
    public class Channel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public List<string> Members { get; set; }
        public int MaximumCapacity { get; set; }
        public bool Temporary { get; set; }
        public ChannelVisibility Visibility { get; set; }
        public List<string> VisibilityScope { get; set; }
        public ChannelProtection Protection { get; set; }
        public string Password { get; set; }
        public List<string> Whitelist { get; set; }
        public List<string> Blacklist { get; set; }
    }

    public enum ChannelProtection
    {
        Invite,
        Request,
        Password,
        None
    }

    public enum ChannelVisibility
    {
        Hidden,
        HiddenFor,
        Visible,
        VisibleFor
    }
}
