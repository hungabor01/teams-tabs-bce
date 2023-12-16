using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.Models
{
    public class TaskResultModel : IModel
    {
        private readonly int[] _validResults = new[] { -1, 0, 1 };

        public string UserEmail { get; }
        public TaskIdentifierModel TaskIdentifierModel { get; }
        public int Result { get; }

        public TaskResultModel(string userEmail, TaskIdentifierModel taskIdentifierModel, int result)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));
            taskIdentifierModel.ThrowExceptionIfNull(nameof(taskIdentifierModel));

            UserEmail = userEmail;
            TaskIdentifierModel = taskIdentifierModel;
            Result = result;

            VerifyProperties();
        }

        public TaskResultModel(string userEmail, string data)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));
            data.ThrowExceptionIfNullOrWhiteSpace(nameof(data));

            UserEmail = userEmail;

            var dataParts = data.Split(' ');
            if (dataParts.Length != 2)
            {
                throw new ArgumentException($"Invalid data: {data} in {nameof(TaskResultModel)}.");
            }

            TaskIdentifierModel = new TaskIdentifierModel(dataParts[0]);

            if (!int.TryParse(dataParts[1], out var result))
            {
                throw new ArgumentException($"Invalid result: {dataParts[1]} in {nameof(TaskResultModel)}.");
            }
            Result = result;

            VerifyProperties();
        }

        private void VerifyProperties()
        {
            if (!_validResults.Contains(Result))
            {
                throw new ArgumentException($"{nameof(Result)} should be -1 or 0 or 1, but it is {Result} in {nameof(TaskResultModel)}.");
            }
        }
    }
}
