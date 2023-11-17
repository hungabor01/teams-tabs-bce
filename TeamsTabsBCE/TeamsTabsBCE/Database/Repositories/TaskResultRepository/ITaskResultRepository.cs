using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Repositories.TaskResultRepository
{
    public interface ITaskResultRepository
    {
        public Task<IList<TaskResult>> GetTaskResultsForUser(string userEmail);

        public Task<TaskResult> StoreTaskResult(TaskResult taskResult);
    }
}
