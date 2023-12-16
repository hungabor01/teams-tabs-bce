using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Repositories.TeamsConversationRepository
{
    public interface ITeamsConversationRepository
    {
        public Task<TeamsConversation?> GetTeamsConversation(TaskIdentifier taskIdentifier);

        public Task<TeamsConversation> StoreTeamsConversation(TeamsConversation teamsConversation);
    }
}
