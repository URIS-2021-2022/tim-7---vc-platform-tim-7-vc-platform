using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.Events
{
    public class ChangedIntegratrionEvent<TEntity> : IntegrationEventBase<TEntity> where TEntity : IEntity
    {
        public ChangedIntegratrionEvent(TEntity entity, params (string Key, object Value)[] keyValuePairs)
            : base(entity, keyValuePairs)
        {
        }
    }
}
