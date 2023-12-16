namespace TeamsTabsBCE.Domain.Models
{
    public class FullTaskIdentifierModel : TaskIdentifierModel
    {
        public TeamsConversationModel? TeamsConversationModel { get; }
        public IList<TaskResultModel> TaskResultModels { get; }

        public FullTaskIdentifierModel(TaskIdentifierModel taskIdentifierModel,
            TeamsConversationModel? teamsConversationModel, IList<TaskResultModel> taskResultModels)
            : base(taskIdentifierModel.Week, taskIdentifierModel.List, taskIdentifierModel.Step)
        {

            TeamsConversationModel = teamsConversationModel;
            TaskResultModels = taskResultModels;
        }
    }
}
