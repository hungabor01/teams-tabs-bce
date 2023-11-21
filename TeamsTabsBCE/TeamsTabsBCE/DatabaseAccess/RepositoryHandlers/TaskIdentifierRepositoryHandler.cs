using TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskResultMapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TeamsConversationMapper;
using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers
{
    internal class TaskIdentifierRepositoryHandler : RepositoryHandlerBase, ITaskIdentifierRepositoryHandler
    {
        private readonly ITaskIdentifierMapper _taskIdentifierMapper;
        private readonly ITeamsConversationMapper _teamsConversationMapper;
        private readonly ITaskResultMapper _taskResultMapper;

        public TaskIdentifierRepositoryHandler(
            IServiceProvider serviceProvider,
            ITaskIdentifierMapper taskIdentifierMapper,
            ITeamsConversationMapper teamsConversationMapper,
            ITaskResultMapper taskResultMapper)
            : base(serviceProvider)
        {
            _taskResultMapper = taskResultMapper;
            _teamsConversationMapper = teamsConversationMapper;
            _taskIdentifierMapper = taskIdentifierMapper;
        }

        public async Task<IList<FullTaskIdentifierModel>> GetAllTaskIdentifiers()
        {
            var fullTaskIdentifierModels = new List<FullTaskIdentifierModel>();

            var unitOfWork = GetUnitOfWork();
            var taskIdentifiers = await unitOfWork.TaskIdentifierRepository.GetAllTaskIdentifiers();
            foreach (var taskIdentifier in taskIdentifiers)
            {
                var teamsConversationModel = taskIdentifier.TeamsConversation != null
                    ? _teamsConversationMapper.ToModel(taskIdentifier.TeamsConversation)
                    : null;
                var taskResultModels = _taskResultMapper.ToModels(taskIdentifier.TaskResults);
                var taskIdentifierModel = _taskIdentifierMapper.ToModel(taskIdentifier);
                fullTaskIdentifierModels.Add(new FullTaskIdentifierModel(taskIdentifierModel, teamsConversationModel, taskResultModels));
            }

            return fullTaskIdentifierModels;
        }
    }
}
