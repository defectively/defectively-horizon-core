using Defectively.Core.Common;

namespace Defectively.Core.Extensibility
{
    public static class ComponentPool
    {
        public static IClientWrapper ClientWrapper { get; set; }
        public static IServerWrapper ServerWrapper { get; set; }
    }
}
