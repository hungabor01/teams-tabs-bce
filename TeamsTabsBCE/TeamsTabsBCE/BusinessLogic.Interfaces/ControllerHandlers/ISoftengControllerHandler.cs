using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.Softeng;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers
{
    public interface ISoftengControllerHandler
    {
        public SoftengViewModel GetViewModel();

        public Task<IList<TaskResultModel>> GetTaskResultsForUser(string userEmail);

        public Task StoreTaskResult(TaskResultModel taskResultModel);

        public Task<string?> GetTeamsConversationId(TaskIdentifierModel taskIdentifierModel);

        public Task StoreTeamsConversation(TeamsConversationModel teamsConversationModel);
    }
}