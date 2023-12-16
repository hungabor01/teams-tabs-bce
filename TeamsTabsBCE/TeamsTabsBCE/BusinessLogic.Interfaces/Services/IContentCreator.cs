using TeamsTabsBCE.Domain.ViewModels.Softeng;
using TeamsTabsBCE.Domain.ViewModels.SoftengDashboard;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.Services
{
    public interface IContentCreator
    {
        public SoftengViewModel CreateSoftengContent();

        public SoftengDashboardViewModel CreateSoftengDashboardContent();
    }
}
