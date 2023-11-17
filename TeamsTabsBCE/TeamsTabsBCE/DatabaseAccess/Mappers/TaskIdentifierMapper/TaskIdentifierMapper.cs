using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.DatabaseAccess.Mappers.Mapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.Mappers.TaskIdentifierMapper
{
    internal class TaskIdentifierMapper : Mapper<TaskIdentifier, TaskIdentifierModel>, ITaskIdentifierMapper
    {
        public override TaskIdentifier FromModel(TaskIdentifierModel model)
        {
            model.ThrowExceptionIfNull(nameof(model));

            return new TaskIdentifier(model.Week, model.List, model.Step);
        }

        public override TaskIdentifierModel ToModel(TaskIdentifier entity)
        {
            entity.ThrowExceptionIfNull(nameof(entity));

            return new TaskIdentifierModel(entity.Week, entity.List, entity.Step);
        }
    }
}
