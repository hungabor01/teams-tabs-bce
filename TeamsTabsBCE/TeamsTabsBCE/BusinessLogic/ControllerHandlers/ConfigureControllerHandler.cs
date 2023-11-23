using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.DatabaseAccess.RepositoryHandlers;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.BusinessLogic.ControllerHandlers
{
    internal class ConfigureControllerHandler : IConfigureControllerHandler
    {
        private readonly ISettingsRepositoryHandler _settingsRepositoryHandler;

        public ConfigureControllerHandler(ISettingsRepositoryHandler settingsRepositoryHandler)
        {
            _settingsRepositoryHandler = settingsRepositoryHandler;
        }

        public async Task StoreSettings(SettingsModel settingsModel)
        {
            settingsModel.ThrowExceptionIfNull(nameof(settingsModel));

            await _settingsRepositoryHandler.StoreSettings(settingsModel);
        }
    }
}
