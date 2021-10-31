using System.Threading;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Events;

namespace VirtoCommerce.Platform.Core.Bus
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default(CancellationToken)) where T : IntegrationEventBase<IEntity>, IEvent;
    }
}
