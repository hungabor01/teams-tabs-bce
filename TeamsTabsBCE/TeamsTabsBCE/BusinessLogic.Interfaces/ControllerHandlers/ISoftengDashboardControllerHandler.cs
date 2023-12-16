using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.SoftengDashboard;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers
{
    public interface ISoftengDashboardControllerHandler
    {
        public Task<SoftengDashboardViewModel> GetSoftengDashboardViewModel();

        public Task<SettingsModel> GetSettings();
    }
}
