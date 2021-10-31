using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;
using VirtoCommerce.Platform.Core.Messages;

namespace VirtoCommerce.Platform.Core.Bus
{
    public abstract class EventBusBase : IEventBus, IHandlerRegistrar
    {
        protected readonly Dictionary<Type, List<Func<IMessage, CancellationToken, Task>>> _routes = new Dictionary<Type, List<Func<IMessage, CancellationToken, Task>>>();

        public void RegisterHandler<T>(Func<T, CancellationToken, Task> handler) where T : class, IMessage
        {
            if (!_routes.TryGetValue(typeof(T), out var handlers))
            {
                handlers = new List<Func<IMessage, CancellationToken, Task>>();
                _routes.Add(typeof(T), handlers);
            }
            handlers.Add((message, token) => handler((T)message, token));
        }

        public async Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : IntegrationEventBase<IEntity>, IEvent
        {
            //TODO @event cast to IntegrationEvent<T>
            if (!EventSuppressor.EventsSuppressed && _routes.TryGetValue(@event.GetType(), out var handlers))
            {
                await Task.WhenAll(handlers.Select(handler => handler(@event, cancellationToken)));
            }
        }

    }
}
