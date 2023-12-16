using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess
{
    public interface ITaskResultRepositoryHandler
    {
        public Task<IList<TaskResultModel>> GetTaskResultsForUser(string userEmail);

        public Task StoreTaskResult(TaskResultModel taskResultModel);
    }
}