using System;
using System.Runtime.Serialization;

namespace VirtoCommerce.Platform.Core.Exceptions
{
    [Serializable]
    public class LicenseOrKeyNotFoundException : PlatformException
    {
        protected LicenseOrKeyNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
        public LicenseOrKeyNotFoundException(string path) : base($"The License or Public Key {path} aren't found.")
        {
            
        }
        public LicenseOrKeyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
