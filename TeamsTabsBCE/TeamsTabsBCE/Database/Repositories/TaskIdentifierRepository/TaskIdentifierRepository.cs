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

        public async Task<TaskIdentifier> GetOrCreateTaskIdentifier(TaskIdentifier taskIdentifier)
        {
            var taskIdentifierInDb = await SingleOrDefaultAsync(ti => ti.Week == taskIdentifier.Week
                                                                      && ti.List == taskIdentifier.List
                                                                      && ti.Step == taskIdentifier.Step);
            return taskIdentifierInDb
                ?? await AddAsync(taskIdentifier);
        }
    }
}
