using System.Threading.Tasks;
using Defectively.Core.Communication;
using Defectively.Core.Extensibility;
using Defectively.Core.Networking;

namespace Defectively.Core.Common
{
    public interface IClientWrapper : IWrapper
    {
        Client Client { get; set; }

        Task SendExternalEventToServer(string name, params object[] @params);
        Task SendPackageToServer(Package package);

        void ShowWindow(IExtensionWindow window);
        bool? ShowWindowDialog(IExtensionWindow window);
    }
}
