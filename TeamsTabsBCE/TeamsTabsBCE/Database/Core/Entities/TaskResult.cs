using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Database.Core.Entities
{
    public class TaskResult : IEntity
    {
        public int Id { get; set; }
        public string UserEmail { get; set; }
        public int TaskIdentifierId { get; set; }
        public TaskIdentifier TaskIdentifier { get; set; } = new TaskIdentifier(0, 0, 0);
        public int Result { get; set; }

        public TaskResult(string userEmail, int result)
        {
            userEmail.ThrowExceptionIfNullOrWhiteSpace(nameof(userEmail));

            UserEmail = userEmail;
            Result = result;
        }
    }
}
