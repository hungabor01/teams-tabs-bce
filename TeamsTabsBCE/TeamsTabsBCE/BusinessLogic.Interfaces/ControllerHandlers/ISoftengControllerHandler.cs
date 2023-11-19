using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers
{
    public interface ISoftengControllerHandler
    {
        public Task<IList<TaskResultModel>> GetTaskResultsForUser(string userEmail);

        public Task StoreTaskResult(TaskResultModel taskResultModel);

        public Task<string?> GetTeamsConversationId(TaskIdentifierModel taskIdentifierModel);

        public Task StoreTeamsConversation(TeamsConversationModel teamsConversationModel);
    }
}