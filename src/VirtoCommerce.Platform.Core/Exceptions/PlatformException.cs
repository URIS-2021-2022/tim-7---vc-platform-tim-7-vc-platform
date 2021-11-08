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
        protected PlatformException(SerializationInfo info, StreamingContext context) : base(info, context)
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

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
           
        }
    }

}
