using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.DatabaseAccess.Mappers.Mapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.Mappers.TeamsConversationMapper
{
    internal class TeamsConversationMapper : Mapper<TeamsConversation, TeamsConversationModel>, ITeamsConversationMapper
    {
        private readonly ITaskIdentifierMapper _taskIdentifierMapper;

        public TeamsConversationMapper(ITaskIdentifierMapper taskIdentifierMapper)
        {
            _taskIdentifierMapper = taskIdentifierMapper;
        }

        public override TeamsConversation FromModel(TeamsConversationModel model)
        {
            model.ThrowExceptionIfNull(nameof(model));

            var taskIdentifier = _taskIdentifierMapper.FromModel(model.TaskIdentifierModel);
            return new TeamsConversation(model.ConversationId)
            {
                TaskIdentifier = taskIdentifier,
            };
        }

        public override TeamsConversationModel ToModel(TeamsConversation entity)
        {
            entity.ThrowExceptionIfNull(nameof(entity));

            var taskIdentifierModel = _taskIdentifierMapper.ToModel(entity.TaskIdentifier);
            return new TeamsConversationModel(entity.ConversationId, taskIdentifierModel);
        }
    }
}
