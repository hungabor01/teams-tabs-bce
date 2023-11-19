using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TeamsConversationMapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers
{
    internal class TeamsConversationRepositoryHandler : RepositoryHandlerBase, ITeamsConversationRepositoryHandler
    {
        private readonly ITeamsConversationMapper _teamsConversationMapper;
        private readonly ITaskIdentifierMapper _taskIdentifierMapper;

        public TeamsConversationRepositoryHandler(
            IServiceProvider serviceProvider,
            ITeamsConversationMapper teamsConversationMapper,
            ITaskIdentifierMapper taskIdentifierMapper)
            : base(serviceProvider)
        {
            _teamsConversationMapper = teamsConversationMapper;
            _taskIdentifierMapper = taskIdentifierMapper;
        }

        public async Task<TeamsConversationModel?> GetTeamsConversation(TaskIdentifierModel taskIdentifierModel)
        {
            taskIdentifierModel.ThrowExceptionIfNull(nameof(taskIdentifierModel));

            var unitOfWork = GetUnitOfWork();
            var taskIdentifier = _taskIdentifierMapper.FromModel(taskIdentifierModel);
            taskIdentifier = await unitOfWork.TaskIdentifierRepository.GetOrCreateTaskIdentifier(taskIdentifier);
            var teamsConversation = await unitOfWork.TeamsConversationRepository.GetTeamsConversation(taskIdentifier);
            return teamsConversation != null
                ? _teamsConversationMapper.ToModel(teamsConversation)
                : null;
        }

        public async Task StoreTeamsConversation(TeamsConversationModel teamsConversationModel)
        {
            teamsConversationModel.ThrowExceptionIfNull(nameof(teamsConversationModel));

            var unitOfWork = GetUnitOfWork();
            var teamsConversation = _teamsConversationMapper.FromModel(teamsConversationModel);
            teamsConversation.TaskIdentifier = await unitOfWork.TaskIdentifierRepository.GetOrCreateTaskIdentifier(teamsConversation.TaskIdentifier);
            await unitOfWork.TeamsConversationRepository.StoreTeamsConversation(teamsConversation);
            await unitOfWork.CompleteAsync();
        }
    }
}
