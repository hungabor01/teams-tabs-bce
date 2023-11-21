using TeamsTabsBCE.Domain.ViewModels;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers
{
    public interface ISoftengDashboardControllerHandler
    {
        public Task<SoftengDashboardViewModel> GetSoftengDashboardViewModel();
    }
}
