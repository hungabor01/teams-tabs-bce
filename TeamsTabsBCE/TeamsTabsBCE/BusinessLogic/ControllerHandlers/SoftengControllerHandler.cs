using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.BusinessLogic.Interfaces.Services;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.Softeng;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.BusinessLogic.ControllerHandlers
{
    internal class SoftengControllerHandler : ISoftengControllerHandler
    {
        private readonly IContentCreator _contentCreator;
        private readonly ITaskResultRepositoryHandler _taskResultRepositoryHandler;
        private readonly ITeamsConversationRepositoryHandler _teamsConversationRepositoryHandler;

        public SoftengControllerHandler(
            IContentCreator contentCreator,
            ITaskResultRepositoryHandler taskResultRepositoryHandler,
            ITeamsConversationRepositoryHandler teamsConversationRepositoryHandler)
        {
            _contentCreator = contentCreator;
            _taskResultRepositoryHandler = taskResultRepositoryHandler;
            _teamsConversationRepositoryHandler = teamsConversationRepositoryHandler;
        }

        public SoftengViewModel GetViewModel()
        {
            return _contentCreator.CreateSoftengContent();
        }

        public async Task<IList<TaskResultModel>> GetTaskResultsForUser(string userEmail)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));

            return await _taskResultRepositoryHandler.GetTaskResultsForUser(userEmail);
        }

        public async Task StoreTaskResult(TaskResultModel taskResultModel)
        {
            taskResultModel.ThrowExceptionIfNull(nameof(taskResultModel));

            await _taskResultRepositoryHandler.StoreTaskResult(taskResultModel);
        }

        public async Task<string?> GetTeamsConversationId(TaskIdentifierModel taskIdentifierModel)
        {
            taskIdentifierModel.ThrowExceptionIfNull(nameof(taskIdentifierModel));

            var teamsConversationModel = await _teamsConversationRepositoryHandler.GetTeamsConversation(taskIdentifierModel);
            return teamsConversationModel?.ConversationId;
        }

        public async Task StoreTeamsConversation(TeamsConversationModel teamsConversationModel)
        {
            teamsConversationModel.ThrowExceptionIfNull(nameof(teamsConversationModel));

            await _teamsConversationRepositoryHandler.StoreTeamsConversation(teamsConversationModel);
        }
    }
}
