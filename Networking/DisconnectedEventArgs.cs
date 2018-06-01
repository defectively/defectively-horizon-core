using System;

namespace Defectively.Core.Networking
{
    /// <summary>
    ///     Provides data for the <see cref="ConnectableBase.Disconnected"/> event handler.
    /// </summary>
    public class DisconnectedEventArgs : EventArgs
    {
        /// <summary>
        ///     The <see cref="Client"/> that connected.
        /// </summary>
        public Client Client { get; }

        /// <inheritdoc />
        public DisconnectedEventArgs() { }

        /// <inheritdoc />
        public DisconnectedEventArgs(Client client) {
            Client = client;
        }
    }
}
