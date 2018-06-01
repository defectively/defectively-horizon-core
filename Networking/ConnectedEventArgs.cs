using System;

namespace Defectively.Core.Networking
{
    /// <summary>
    ///     Provides data for the <see cref="ConnectableBase.Connected"/> event handler.
    /// </summary>
    public class ConnectedEventArgs : EventArgs
    {
        /// <summary>
        ///     The <see cref="Client"/> that connected.
        /// </summary>
        public Client Client { get; }

        /// <inheritdoc />
        public ConnectedEventArgs() { }

        /// <inheritdoc />
        public ConnectedEventArgs(Client client) {
            Client = client;
        }
    }
}
