namespace TeamsTabsBCE.Database.Core.Entities
{
    public class TaskIdentifier : IEntity
    {
        public int Id { get; set; }
        public int Week { get; set; }
        public int List { get; set; }
        public int Step { get; set; }
        public virtual TeamsConversation? TeamsConversation { get; set; }
        public virtual ICollection<TaskResult> TaskResults { get; set; } = new HashSet<TaskResult>();

        public TaskIdentifier(int week, int list, int step)
        {
            Week = week;
            List = list;
            Step = step;
        }
    }
}
