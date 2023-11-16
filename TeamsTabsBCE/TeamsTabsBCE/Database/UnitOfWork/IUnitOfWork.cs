﻿using TeamsTabsBCE.Database.Repositories.TaskIdentifierRepository;
using TeamsTabsBCE.Database.Repositories.TaskResultRepository;
using TeamsTabsBCE.Database.Repositories.TeamsConversationRepository;

namespace TeamsTabsBCE.Database.UnitOfWork
{
    public interface IUnitOfWork
    {
        public ITaskIdentifierRepository TaskIdentifierRepository { get; }
        public ITaskResultRepository TaskResultRepository { get; }
        public ITeamsConversationRepository TeamsConversationRepository { get; }

        public int Complete();

        public Task<int> CompleteAsync();
    }
}
