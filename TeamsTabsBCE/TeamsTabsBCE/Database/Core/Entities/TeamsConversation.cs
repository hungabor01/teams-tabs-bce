namespace TeamsTabsBCE.Database.Core.Entities
{
    public class TeamsConversation
    {
        public int Id { get; set; }
        public string? ConversationId { get; set; }
        public int TaskIdentifierId { get; set; }
        public TaskIdentifier? TaskIdentifier { get; set; }
    }
}
