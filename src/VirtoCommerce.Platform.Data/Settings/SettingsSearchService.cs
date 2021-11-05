using System.Linq;
using System.Threading.Tasks;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Settings;

namespace VirtoCommerce.Platform.Data.Settings
{
    public class SettingsSearchService : ISettingsSearchService
    {
        private readonly ISettingsManager _settingsManager;

        public SettingsSearchService(ISettingsManager settingsManager)
        {
            _settingsManager = settingsManager;
        }
        public async Task<GenericSearchResult<ObjectSettingEntry>> SearchSettingsAsync(SettingsSearchCriteria searchCriteria)
        {
            var result = new GenericSearchResult<ObjectSettingEntry>();

            var query = _settingsManager.AllRegisteredSettings.AsQueryable();

            if (!string.IsNullOrEmpty(searchCriteria.ModuleId))
            {
                query = query.Where(x => x.ModuleId == searchCriteria.ModuleId);
            }

            var sortInfos = searchCriteria.SortInfos;
            if (sortInfos.IsNullOrEmpty())
            {
                sortInfos = new[] { new SortInfo { SortColumn = "Name" } };
            }
            query = query.OrderBySortInfos(sortInfos);
            result.TotalCount = query.Count();
            var names = query.Skip(searchCriteria.Skip).Take(searchCriteria.Take).Select(x => x.Name).ToList();

            var settings = await _settingsManager.GetObjectSettingsAsync(names.ToArray());
            result.Results = settings.OrderBy(x => names.IndexOf(x.Name))
                                       .ToList();
            return result;
        }
    }
}
