using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers
{
    public interface ITaskIdentifierRepositoryHandler
    {
        public Task<IList<FullTaskIdentifierModel>> GetAllTaskIdentifiers();
    }
}