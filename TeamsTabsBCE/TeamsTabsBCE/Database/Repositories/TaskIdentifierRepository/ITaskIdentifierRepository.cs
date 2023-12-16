using TeamsTabsBCE.Database.Core.Entities;

namespace TeamsTabsBCE.Database.Repositories.TaskIdentifierRepository
{
    public interface ITaskIdentifierRepository
    {
        public Task<TaskIdentifier> GetOrCreateTaskIdentifier(TaskIdentifier taskIdentifier);

        public Task<IList<TaskIdentifier>> GetAllTaskIdentifiers();
    }
}
