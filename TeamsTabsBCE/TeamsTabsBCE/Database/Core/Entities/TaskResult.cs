namespace TeamsTabsBCE.Database.Core.Entities
{
    public class TaskResult
    {
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        public int TaskIdentifierId { get; set; }
        public TaskIdentifier? TaskIdentifier { get; set; }
        public int Result { get; set; }
    }
}
