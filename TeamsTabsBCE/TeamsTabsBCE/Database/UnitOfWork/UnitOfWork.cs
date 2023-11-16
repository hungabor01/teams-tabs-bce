using TeamsTabsBCE.Database.Core;
using TeamsTabsBCE.Database.Repositories.TaskIdentifierRepository;
using TeamsTabsBCE.Database.Repositories.TaskResultRepository;
using TeamsTabsBCE.Database.Repositories.TeamsConversationRepository;

namespace TeamsTabsBCE.Database.UnitOfWork
{
    internal sealed class UnitOfWork : IUnitOfWork
    {
        private readonly BceDbContext _context;

        public ITaskIdentifierRepository TaskIdentifierRepository { get; }
        public ITaskResultRepository TaskResultRepository { get; }
        public ITeamsConversationRepository TeamsConversationRepository { get; }

        public UnitOfWork(BceDbContext context)
        {
            _context = context;

            TaskIdentifierRepository = new TaskIdentifierRepository(_context);
            TaskResultRepository = new TaskResultRepository(_context);
            TeamsConversationRepository = new TeamsConversationRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
