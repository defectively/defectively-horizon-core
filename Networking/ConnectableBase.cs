﻿using System;
using Defectively.Core.Cryptography;

namespace Defectively.Core.Networking
{
    /// <summary>
    ///     Represents the base of the <see cref="Server"/> and <see cref="Client"/> classes.
    /// </summary>
    public abstract class ConnectableBase
    {
        /// <summary>
        ///     The <see cref="CryptographicData"/> asigned to this <see cref="ConnectableBase"/>.
        /// </summary>
        /// <remarks>Not set on <see cref="Server"/> instances.</remarks>
        public CryptographicData CryptographicData { get; set; }

        /// <inheritdoc />
        public delegate void ConnectedEventHandler(ConnectableBase sender, ConnectedEventArgs e);

        /// <summary>
        ///     Occurs when a <see cref="Client"/> connects to a <see cref="Server"/>.
        /// </summary>
        public event ConnectedEventHandler Connected;

        /// <inheritdoc />
        public delegate void DisconnectedEventHandler(ConnectableBase sender, DisconnectedEventArgs e);

        /// <summary>
        ///     Occurs when a <see cref="Client"/> disconnects.
        /// </summary>
        public event DisconnectedEventHandler Disconnected;

        /// <summary>
        ///     Raises the <see cref="Connected"/> event
        /// </summary>
        /// <param name="sender">The <see cref="ConnectableBase"/> raising this event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnConnected(ConnectableBase sender, ConnectedEventArgs e) {
            Connected?.Invoke(sender, e);
        }

        /// <summary>
        ///     Raises the <see cref="Disconnected"/> event
        /// </summary>
        /// <param name="sender">The <see cref="ConnectableBase"/> raising this event.</param>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnDisconnected(ConnectableBase sender, DisconnectedEventArgs e) {
            Disconnected?.Invoke(sender, e);
        }
    }
}
