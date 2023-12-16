using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.BusinessLogic.Interfaces.Services;
using TeamsTabsBCE.DatabaseAccess.RepositoryHandlers;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.SoftengDashboard;

namespace TeamsTabsBCE.BusinessLogic.ControllerHandlers
{
    internal class SoftengDashboardControllerHandler : ISoftengDashboardControllerHandler
    {
        private readonly ISettingsRepositoryHandler _settingsRepositoryHandler;
        private readonly ITaskIdentifierRepositoryHandler _taskIdentifierRepositoryHandler;
        private readonly IContentCreator _contentCreator;

        public SoftengDashboardControllerHandler(
            ISettingsRepositoryHandler settingsRepositoryHandler,
            ITaskIdentifierRepositoryHandler taskIdentifierRepositoryHandler,
            IContentCreator contentCreator)
        {
            _settingsRepositoryHandler = settingsRepositoryHandler;
            _taskIdentifierRepositoryHandler = taskIdentifierRepositoryHandler;
            _contentCreator = contentCreator;
        }

        public async Task<SoftengDashboardViewModel> GetSoftengDashboardViewModel()
        {
            var fullTaskIdentifierModels = await _taskIdentifierRepositoryHandler.GetAllTaskIdentifiers();

            var softengDashboardViewModel = _contentCreator.CreateSoftengDashboardContent();
            foreach (var week in softengDashboardViewModel.Weeks)
            {
                foreach (var list in week.Lists)
                {
                    var fullTaskIdentifierModelsForList = fullTaskIdentifierModels
                        .Where(fti => fti.Week == list.MaxTaskIdentifier.Week && fti.List == list.MaxTaskIdentifier.List);

                    foreach (var fullTaskIdentifierModel in fullTaskIdentifierModelsForList)
                    {
                        list.FullTaskIdentifierModels.Add(fullTaskIdentifierModel);
                    }
                }
            }

            return softengDashboardViewModel;
        }

        public async Task<SettingsModel> GetSettings()
        {
            return await _settingsRepositoryHandler.GetSettings();
        }
    }
}
