using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Database.Repositories.Repository;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Database.Repositories.TaskResultRepository
{
    internal class TaskResultRepository : Repository<TaskResult>, ITaskResultRepository
    {
        public TaskResultRepository(BceDbContext context) : base(context)
        {
        }

        public async Task<IList<TaskResult>> GetTaskResultsForUser(string userEmail)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));

            return await FindAsync(tr => tr.UserEmail == userEmail, tr => tr.TaskIdentifier);
        }

        public async Task<TaskResult> StoreTaskResult(TaskResult taskResult)
        {
            taskResult.ThrowExceptionIfNull(nameof(taskResult));

            var taskResultInDb = await SingleOrDefaultAsync(tr => tr.UserEmail == taskResult.UserEmail
                                                                  && tr.TaskIdentifier.Id == taskResult.TaskIdentifier.Id);
            if (taskResultInDb != null)
            {
                taskResultInDb.Result = taskResult.Result;
                return taskResultInDb;
            }

            return await AddAsync(taskResult);
        }
    }
}
