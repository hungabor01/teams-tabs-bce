using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.DatabaseAccess.Mappers.Mapper;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.Mappers.TaskResultMapper
{
    internal class TaskResultMapper : Mapper<TaskResult, TaskResultModel>, ITaskResultMapper
    {
        private readonly ITaskIdentifierMapper _taskIdentifierMapper;

        public TaskResultMapper(ITaskIdentifierMapper taskIdentifierMapper)
        {
            _taskIdentifierMapper = taskIdentifierMapper;
        }

        public override TaskResult FromModel(TaskResultModel model)
        {
            model.ThrowExceptionIfNull(nameof(model));

            var taskIdentifier = _taskIdentifierMapper.FromModel(model.TaskIdentifierModel);
            return new TaskResult(model.UserEmail, model.Result)
            {
                TaskIdentifier = taskIdentifier,
            };
        }

        public override TaskResultModel ToModel(TaskResult entity)
        {
            entity.ThrowExceptionIfNull(nameof(entity));

            var taskIdentifierModel = _taskIdentifierMapper.ToModel(entity.TaskIdentifier);
            return new TaskResultModel(entity.UserEmail, taskIdentifierModel, entity.Result);
        }
    }
}
