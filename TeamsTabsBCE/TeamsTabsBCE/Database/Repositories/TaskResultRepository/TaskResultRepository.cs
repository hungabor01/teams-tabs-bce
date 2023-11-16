using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Repositories.Repository;

namespace TeamsTabsBCE.Database.Repositories.TaskResultRepository
{
    internal class TaskResultRepository : Repository<TaskResult>, ITaskResultRepository
    {
        public TaskResultRepository(BceDbContext context) : base(context)
        {
        }
    }
}
