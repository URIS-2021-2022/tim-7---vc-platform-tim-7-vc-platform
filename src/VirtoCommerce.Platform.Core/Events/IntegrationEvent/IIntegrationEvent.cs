using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.Events
{
    public interface IIntegrationEvent<out TEntity> where TEntity : IEntity
    {
        TEntity Entity { get; }
    }
}
