using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers
{
    public interface ISettingsRepositoryHandler
    {
        public Task<SettingsModel> GetSettings();

        public Task StoreSettings(SettingsModel settingsModel);
    }
}