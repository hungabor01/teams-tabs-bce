using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.DatabaseAccess.RepositoryHandlers;
using TeamsTabsBCE.Domain.ViewModels;

namespace TeamsTabsBCE.BusinessLogic.ControllerHandlers
{
    internal class SoftengDashboardControllerHandler : ISoftengDashboardControllerHandler
    {
        private readonly ITaskIdentifierRepositoryHandler _taskIdentifierRepositoryHandler;

        public SoftengDashboardControllerHandler(ITaskIdentifierRepositoryHandler taskIdentifierRepositoryHandler)
        {
            _taskIdentifierRepositoryHandler = taskIdentifierRepositoryHandler;
        }

        public async Task<SoftengDashboardViewModel> GetSoftengDashboardViewModel()
        {
            var fullTaskIdentifierModels = await _taskIdentifierRepositoryHandler.GetAllTaskIdentifiers();
            return new SoftengDashboardViewModel(fullTaskIdentifierModels);
        }
    }
}
