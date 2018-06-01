using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Defectively.Core.Common;
using Defectively.Core.Extensibility.Events;

namespace Defectively.Core.Extensibility
{
    public abstract class Extension
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Version Version { get; set; }
        public IEnumerable<EventType> ClientEvents { get; set; }
        public IEnumerable<EventType> ServerEvents { get; set; }
        public bool CreateClientInstance { get; set; }
        public bool CreateStorage { get; set; }
        public string StoragePath { get; set; }
        public string ExtensionPath { get; set; }
        public bool Disabled { get; set; }
        
        public abstract void OnInitialize(bool isServerside);
        
        public virtual void OnLoad() { }

        public async virtual Task OnExternalEvent(IClientWrapper sender, ExternalEvent @event) { }
        public async virtual Task OnExternalEvent(IServerWrapper sender, ExternalEvent @event) { }

        public virtual void OnPackageReceived(IClientWrapper sender, PackageReceivedEvent @event) { }
        public virtual void OnPackageReceived(IServerWrapper sender, PackageReceivedEvent @event) { }

        public virtual void OnInputReceived(IClientWrapper sender, InputReceivedEvent @event) { }
        public virtual void OnInputReceived(IServerWrapper sender, InputReceivedEvent @event) { }
        
        public virtual void OnConnected(IClientWrapper sender, ConnectedEvent @event) { }
        public virtual void OnConnected(IServerWrapper sender, ConnectedEvent @event) { }

        public virtual void OnAuthenticated(IClientWrapper sender, AuthenticatedEvent @event) { }
        public virtual void OnAuthenticated(IServerWrapper sender, AuthenticatedEvent @event) { }
    }
}