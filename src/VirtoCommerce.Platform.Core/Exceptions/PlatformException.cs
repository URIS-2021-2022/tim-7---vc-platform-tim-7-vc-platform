using System;
using System.Runtime.Serialization;

namespace VirtoCommerce.Platform.Core.Exceptions
{
    /// <summary>
    /// Main platform exception type
    /// </summary>
    ///

    [Serializable]
    public class PlatformException : Exception
    {
        protected PlatformException(SerializationInfo info, StreamingContext context)
        {

        }

        public PlatformException(string message)
            : base(message)
        {
        }

        public PlatformException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
