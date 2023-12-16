using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Repositories.Repository;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Database.Repositories.SettingsRepository
{
    internal class SettingsRepository : Repository<Settings>, ISettingsRepository
    {
        public SettingsRepository(BceDbContext context) : base(context)
        {
        }

        public async Task<Settings?> GetSettings()
        {
            return await SingleOrDefaultAsync(s => true);
        }

        public async Task<Settings> StoreSettings(Settings settings)
        {
            settings.ThrowExceptionIfNull(nameof(settings));

            var settingsInDb = await GetAllAsync();
            if (settingsInDb.Any())
            {
                return settingsInDb.Single();
            }

            return await AddAsync(settings);
        }
    }
}
