using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.BusinessLogic.ControllerHandlers
{
    internal class SoftengControllerHandler : ISoftengControllerHandler
    {
        private readonly ITaskResultRepositoryHandler _taskResultRepositoryHandler;
        private readonly ITeamsConversationRepositoryHandler _teamsConversationRepositoryHandler;

        public SoftengControllerHandler(
            ITaskResultRepositoryHandler taskResultRepositoryHandler,
            ITeamsConversationRepositoryHandler teamsConversationRepositoryHandler)
        {
            _taskResultRepositoryHandler = taskResultRepositoryHandler;
            _teamsConversationRepositoryHandler = teamsConversationRepositoryHandler;
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
