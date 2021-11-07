using System;

namespace VirtoCommerce.Platform.Core.Exceptions
{
    [Serializable]
    public class LicenseOrKeyNotFoundException : PlatformException
    {
        protected LicenseOrKeyNotFoundException(string path) : base($"The License or Public Key {path} aren't found.")
        {
            
        }
        protected LicenseOrKeyNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}
