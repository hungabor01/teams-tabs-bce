using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Repositories.Repository;

namespace TeamsTabsBCE.Database.Repositories.TeamsConversationRepository
{
    internal class TeamsConversationRepository : Repository<TeamsConversation>, ITeamsConversationRepository
    {
        public TeamsConversationRepository(BceDbContext context) : base(context)
        {
        }
    }
}
