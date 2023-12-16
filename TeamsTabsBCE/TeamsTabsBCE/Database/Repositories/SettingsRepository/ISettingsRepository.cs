using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Repositories.SettingsRepository
{
    public interface ISettingsRepository
    {
        public Task<Settings?> GetSettings();

        public Task<Settings> StoreSettings(Settings settings);
    }
}
