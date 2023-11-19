using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.Models
{
    public class TeamsConversationModel : IModel
    {
        public string ConversationId { get; }
        public TaskIdentifierModel TaskIdentifierModel { get; }

        public TeamsConversationModel(string conversationId, TaskIdentifierModel taskIdentifierModel)
        {
            conversationId.ThrowExceptionIfNullOrWhiteSpace(nameof(conversationId));
            taskIdentifierModel.ThrowExceptionIfNull(nameof(taskIdentifierModel));

            ConversationId = conversationId;
            TaskIdentifierModel = taskIdentifierModel;

            VerifyProperties();
        }

        public TeamsConversationModel(string data)
        {
            data.ThrowExceptionIfNullOrWhiteSpace(nameof(data));

            var dataParts = data.Split(' ');
            if (dataParts.Length != 2)
            {
                throw new ArgumentException($"Invalid data: {data} in {nameof(TeamsConversationModel)}.");
            }

            TaskIdentifierModel = new TaskIdentifierModel(dataParts[0]);
            ConversationId = dataParts[1];

            VerifyProperties();
        }

        private void VerifyProperties()
        {
            if (!ConversationId.All(char.IsDigit))
            {
                throw new ArgumentException($"{ConversationId} should be -1 or 0 or 1, but it is {ConversationId} in {nameof(TaskResultModel)}.");
            }
        }
    }
}
