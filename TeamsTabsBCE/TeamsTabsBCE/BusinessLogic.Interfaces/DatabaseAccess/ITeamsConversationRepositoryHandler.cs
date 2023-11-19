using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess
{
    public interface ITeamsConversationRepositoryHandler
    {
        public Task<TeamsConversationModel?> GetTeamsConversation(TaskIdentifierModel taskIdentifierModel);

        public Task StoreTeamsConversation(TeamsConversationModel teamsConversationModel);
    }
}