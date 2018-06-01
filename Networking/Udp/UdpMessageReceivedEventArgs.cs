using System;
using System.Net;

namespace Defectively.Core.Networking.Udp
{
    /// <summary>
    ///     Provides data for the <see cref="UdpReceiver.UdpMessageReceived"/> event handler.
    /// </summary>
    public class UdpMessageReceivedEventArgs : EventArgs
    {
        /// <summary>
        ///     The <see cref="IPEndPoint"/> that sent the message.
        /// </summary>
        public IPEndPoint RemoteEndPoint { get; }

        /// <summary>
        ///     The content of the message.
        /// </summary>
        public string Content { get; }

        /// <inheritdoc />
        public UdpMessageReceivedEventArgs() { }

        /// <inheritdoc />
        public UdpMessageReceivedEventArgs(IPEndPoint endPoint, string content) {
            RemoteEndPoint = endPoint;
            Content = content;
        }
    }
}
