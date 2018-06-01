using System.Threading.Tasks;
using Defectively.Core.Communication;
using Defectively.Core.Networking;

namespace Defectively.Core.Common
{
    public interface IServerWrapper : IWrapper
    {
        // List<Account> Accounts { get; set; }
        // List<Team> Teams { get; set; }
        // List<Channel> Channels { get; set; }
        Server Server { get; set; }

        Task SendPackageTo(Package package, string accountId);
        Task SendPackageToAccounts(Package package, params string[] accountIds);
        Task SendPackageToAccountsWithFlag(Package package, string aresFlag);
        Task SendPackageToTeams(Package package, params string[] teamIds);
        Task SendPackageToChannels(Package package, params string[] channelIds);
        Task SendPackageToAll(Package package);
    }
}
