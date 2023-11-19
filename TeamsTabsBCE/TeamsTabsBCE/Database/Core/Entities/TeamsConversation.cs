namespace TeamsTabsBCE.Database.Core.Entities
{
    public class TeamsConversation : IEntity
    {
        public int Id { get; set; }
        public string ConversationId { get; set; }
        public int TaskIdentifierId { get; set; }
        public TaskIdentifier TaskIdentifier { get; set; } = new TaskIdentifier(0, 0, 0);

        public TeamsConversation(string conversationId)
        {
            ConversationId = conversationId;
        }
    }
}
