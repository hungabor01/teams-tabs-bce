using TeamsTabsBCE.BusinessLogic.Interfaces.DatabaseAccess;
using TeamsTabsBCE.DatabaseAccess.Mappers.TaskResultMapper;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.DatabaseAccess.RepositoryHandlers.TaskResultRepositoryHandler
{
    internal class TaskResultRepositoryHandler : RepositoryHandlerBase, ITaskResultRepositoryHandler
    {
        private readonly ITaskResultMapper _taskResultMapper;

        public TaskResultRepositoryHandler(IServiceProvider serviceProvider, ITaskResultMapper taskResultMapper)
            : base(serviceProvider)
        {
            _taskResultMapper = taskResultMapper;
        }

        public async Task<IList<TaskResultModel>> GetTaskResultsForUser(string userEmail)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));

            var unitOfWork = GetUnitOfWork();
            var taskResults = await unitOfWork.TaskResultRepository.GetTaskResultsForUser(userEmail);
            return _taskResultMapper.ToModels(taskResults);
        }

        public async Task StoreTaskResult(TaskResultModel taskResultModel)
        {
            taskResultModel.ThrowExceptionIfNull(nameof(taskResultModel));

            var unitOfWork = GetUnitOfWork();
            var taskResult = _taskResultMapper.FromModel(taskResultModel);
            taskResult.TaskIdentifier = await unitOfWork.TaskIdentifierRepository.GetOrCreateTaskIdentifier(taskResult.TaskIdentifier);
            await unitOfWork.TaskResultRepository.StoreTaskResult(taskResult);
            await unitOfWork.CompleteAsync();
        }
    }
}
