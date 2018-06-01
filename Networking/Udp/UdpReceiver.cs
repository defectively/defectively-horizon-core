using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Defectively.Core.Networking.Udp
{
    /// <summary>
    ///     Provides methods to listen and receive UDP broadcasts.
    /// </summary>
    public class UdpReceiver
    {
        private readonly UdpClient client;

        private bool cancel;

        /// <inheritdoc />
        public delegate void UdpMessageReceivedEventHandler(UdpReceiver sender, UdpMessageReceivedEventArgs e);

        /// <summary>
        ///     Occurs when a broadcast is received.
        /// </summary>
        public event UdpMessageReceivedEventHandler UdpMessageReceived;

        /// <summary>
        ///     Initialize a new <see cref="UdpReceiver"/> on the given port.
        /// </summary>
        /// <param name="port">The port to listen on.</param>
        public UdpReceiver(int port) {
            client = new UdpClient(new IPEndPoint(IPAddress.Any, port));
        }

        /// <summary>
        ///     Waits for UDP broadcasts to arrive.
        /// </summary>
        /// <returns>This function doesn't return. However the <see cref="UdpMessageReceived"/> event is fired when a message is received.</returns>
        public async Task ReceiveAsync() {
            while (!cancel) {
                try {
                    var result = await client.ReceiveAsync();
                    var content = Encoding.UTF8.GetString(result.Buffer);

                    try {
                        var args = new UdpMessageReceivedEventArgs(result.RemoteEndPoint, content);
                        OnUdpMessageReceived(this, args);
                    } catch { }
                } catch { }
            }
        }

        /// <summary>
        ///     Stops the UDP receiver.
        /// </summary>
        public void Stop() {
            cancel = true;

            client.Close();
            client.Dispose();
        }

        /// <summary>
        ///     Raises the <see cref="UdpMessageReceived"/> event.
        /// </summary>
        /// <param name="sender">The <see cref="UdpReceiver"/> that received the message.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains information about the received message.</param>
        protected virtual void OnUdpMessageReceived(UdpReceiver sender, UdpMessageReceivedEventArgs e) {
            UdpMessageReceived?.Invoke(sender, e);
        }
    }
}
