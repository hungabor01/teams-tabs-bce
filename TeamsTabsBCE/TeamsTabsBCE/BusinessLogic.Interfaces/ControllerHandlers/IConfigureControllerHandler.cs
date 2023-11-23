using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers
{
    public interface IConfigureControllerHandler
    {
        public Task StoreSettings(SettingsModel settingsModel);
    }
}
