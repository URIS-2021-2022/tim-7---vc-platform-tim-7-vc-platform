using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.Events
{
    public class ChangingIntegrationEvent<TEntity> : IntegrationEventBase<TEntity> where TEntity : IEntity
    {
        public ChangingIntegrationEvent(TEntity entity, params (string Key, object Value)[] keyValuePairs)
            : base(entity, keyValuePairs)
        {
        }
    }
}
