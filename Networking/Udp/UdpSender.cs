using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Defectively.Core.Networking.Udp
{
    /// <summary>
    ///     Provides methods to send a UDP broadcast.
    /// </summary>
    public static class UdpSender
    {
        private static readonly UdpClient client = new UdpClient();

        /// <summary>
        ///     Sends a broadcast using the UDP protocol.
        /// </summary>
        /// <param name="content">The content to broadcast.</param>
        /// <param name="port">The port the broadcast should be send to.</param>
        public static void Broadcast(string content, int port) {
            var broadcast = new IPEndPoint(IPAddress.Broadcast, port);
            var data = Encoding.UTF8.GetBytes(content);
            client.Send(data, data.Length, broadcast);
        }

        /// <summary>
        ///     Sends a message using the UDP protocol.
        /// </summary>
        /// <param name="content">The content of the message.</param>
        /// <param name="host">The host the message should be send to.</param>
        /// <param name="port">The port the message should be send to.</param>
        public static void SendMessage(string content, string host, int port) {
            var receiver = new IPEndPoint(IPAddress.Parse(host), port);
            var data = Encoding.UTF8.GetBytes(content);
            client.Send(data, data.Length, receiver);
        }
    }
}
