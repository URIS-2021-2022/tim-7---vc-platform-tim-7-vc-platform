using System.Collections.Generic;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;

namespace VirtoCommerce.Platform.Core.Settings
{
    public interface ISettingsManager : ISettingsRegistrar
    {
        Task<ObjectSettingEntry> GetObjectSettingAsync(string name, TenantIdentity tenantObject = null);
        Task<IEnumerable<ObjectSettingEntry>> GetObjectSettingsAsync(IEnumerable<string> names, TenantIdentity tenantObject = null);
        Task SaveObjectSettingsAsync(IEnumerable<ObjectSettingEntry> objectSettings);
        Task RemoveObjectSettingsAsync(IEnumerable<ObjectSettingEntry> objectSettings);
    }
}
