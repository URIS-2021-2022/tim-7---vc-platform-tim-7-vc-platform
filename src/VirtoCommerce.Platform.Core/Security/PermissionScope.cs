using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.Security
{
    public class PermissionScope : ValueObject
    {
        public PermissionScope()
        {
            Type = GetType().Name;
        }

        /// <summary>
        /// Scope type name
        /// </summary>
        public virtual string Type { get; set; }

        /// <summary>
        /// Display label for particular scope value used only for  representation 
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Represent string scope value
        /// </summary>
        public string Scope { get; set; }

        ////we don't use Json serialization/deserialization due to difficult inject json options on this level

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Scope;
        }

        public virtual void Patch(PermissionScope target)
        {
            target.Label = Label;
            target.Scope = Scope;
        }

    }
}
