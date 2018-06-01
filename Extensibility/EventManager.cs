using System.Collections.Generic;
using System.Linq;
using Defectively.Core.Common;
using Defectively.Core.Extensibility.Events;

namespace Defectively.Core.Extensibility
{
    public static class EventManager
    {
        private static readonly List<Listener> clientListeners = new List<Listener>();
        private static readonly List<Listener> serverListeners = new List<Listener>();

        public static void InvokeEvent(EventType eventType, Event @event, IWrapper context) {
            dynamic wrapper;
            IEnumerable<Extension> extensions;

            if (context is IClientWrapper clientWrapper) {
                wrapper = clientWrapper;
                extensions = clientListeners.Where(l => l.EventType == eventType).Select(l => l.Extension);
            } else {
                wrapper = context as IServerWrapper;
                extensions = serverListeners.Where(l => l.EventType == eventType).Select(l => l.Extension);
            }

            switch (eventType) {
            case EventType.External:
                foreach (var extension in extensions) {
                    extension.OnExternalEvent(wrapper, (ExternalEvent) @event);
                }

                break;

            case EventType.PackageReceived:
                foreach (var extension in extensions) {
                    extension.OnPackageReceived(wrapper, (PackageReceivedEvent) @event);
                }

                break;

            case EventType.InputReceived:
                foreach (var extension in extensions) {
                    extension.OnInputReceived(wrapper, (InputReceivedEvent) @event);
                }

                break;

            case EventType.Connected:
                foreach (var extension in extensions) {
                    extension.OnConnected(wrapper, (ConnectedEvent) @event);
                }

                break;

            case EventType.Authenticated:
                foreach (var extension in extensions) {
                    extension.OnAuthenticated(wrapper, (AuthenticatedEvent) @event);
                }

                break;
            }
        }

        public static void RegisterClientListeners(Extension extension) {
            clientListeners.AddRange(extension.ClientEvents.Select(e => new Listener(e, extension)));
        }

        public static void RegisterServerListeners(Extension extension) {
            serverListeners.AddRange(extension.ServerEvents.Select(e => new Listener(e, extension)));
        }
    }
}
