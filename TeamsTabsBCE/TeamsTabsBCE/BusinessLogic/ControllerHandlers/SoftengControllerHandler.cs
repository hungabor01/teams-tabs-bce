using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.BusinessLogic.ControllerHandlers
{
    internal class SoftengControllerHandler : ISoftengControllerHandler
    {
        private readonly ITaskResultRepositoryHandler _resultRepositoryHandler;

        public SoftengControllerHandler(ITaskResultRepositoryHandler resultRepositoryHandler)
        {
            _resultRepositoryHandler = resultRepositoryHandler;
        }

        public async Task<IList<TaskResultModel>> GetTaskResultsForUser(string userEmail)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));

            return await _resultRepositoryHandler.GetTaskResultsForUser(userEmail);
        }

        public async Task StoreTaskResult(TaskResultModel taskResultModel)
        {
            taskResultModel.ThrowExceptionIfNull(nameof(taskResultModel));

            await _resultRepositoryHandler.StoreTaskResult(taskResultModel);
        }
    }
}
