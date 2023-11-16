using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Repositories.Repository;

namespace TeamsTabsBCE.Database.Repositories.TaskIdentifierRepository
{
    internal class TaskIdentifierRepository : Repository<TaskIdentifier>, ITaskIdentifierRepository
    {
        public TaskIdentifierRepository(BceDbContext context) : base(context)
        {
        }
    }
}
