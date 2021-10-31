using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.Events
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class IntegrationEventBase<TEntity> : DomainEvent, IIntegrationEvent<TEntity> where TEntity : IEntity
    {
        protected readonly Dictionary<string, object> _metaInfo;

        protected IntegrationEventBase(TEntity entity, params (string Key, object Value)[] keyValuePairs)
        {
            Id = Guid.NewGuid().ToString();
            TimeStamp = DateTime.UtcNow;
            Entity = entity;
            _metaInfo = new Dictionary<string, object>();
            _metaInfo.AddRange(keyValuePairs.Select(x => new KeyValuePair<string, object>(x.Key, x.Value)));
        }
                
        /// <summary>
        /// Related entity with this event.
        /// </summary>
        public TEntity Entity { get; }

        public virtual IntegrationEventBase<TEntity> AddMetaInfo(string name, object data)
        {
            _metaInfo.Add(name, data);
            return this;
        }

        public virtual object GetMetaInfo(string name)
        {
            return _metaInfo.GetValueOrDefault(name);
        }

        public object ModuleId
        {
            get => _metaInfo.GetValueOrDefault(EventMetaInfoType.ModuleId);
            set => _metaInfo[EventMetaInfoType.ModuleId] = value;
        }
    }

    public static class IntegrationEventExtension
    {
        public static IntegrationEventBase<TEntity> AddModuleId<TEntity>(this IntegrationEventBase<TEntity> @event, string moduleId) where TEntity : IEntity
        {
            return @event.AddMetaInfo(EventMetaInfoType.ModuleId, moduleId);
        }

        public static Dictionary<string, object> DictionaryFromAnonymousObject(this object o)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            var properties = o.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                dic.Add(prop.Name, prop.GetValue(o, null) as string);
            }
            return dic;
        }
    }
}
