using System.Runtime.Serialization;

namespace VirtoCommerce.Platform.Core.Exceptions
{

    [System.SerializableAttribute]
    public class SettingsTypeNotRegisteredException : PlatformException { 

        protected SettingsTypeNotRegisteredException(SerializationInfo info, StreamingContext context)
       : base("empty")
        { }


        public SettingsTypeNotRegisteredException(string settingsType)
            : base($"Settings for type: {settingsType} not registered, please register it first")
        {
        }
    }
}
