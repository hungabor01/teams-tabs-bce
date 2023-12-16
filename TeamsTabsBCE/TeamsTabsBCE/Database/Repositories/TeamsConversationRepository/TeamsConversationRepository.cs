using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Repositories.Repository;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Database.Repositories.TeamsConversationRepository
{
    internal class TeamsConversationRepository : Repository<TeamsConversation>, ITeamsConversationRepository
    {
        public TeamsConversationRepository(BceDbContext context) : base(context)
        {
        }

        public async Task<TeamsConversation?> GetTeamsConversation(TaskIdentifier taskIdentifier)
        {
            taskIdentifier.ThrowExceptionIfNull(nameof(taskIdentifier));

            return await SingleOrDefaultAsync(tc => tc.TaskIdentifier == taskIdentifier, tc => tc.TaskIdentifier);
        }

        public async Task<TeamsConversation> StoreTeamsConversation(TeamsConversation teamsConversation)
        {
            teamsConversation.ThrowExceptionIfNull(nameof(teamsConversation));

            return await AddAsync(teamsConversation);
        }
    }
}
