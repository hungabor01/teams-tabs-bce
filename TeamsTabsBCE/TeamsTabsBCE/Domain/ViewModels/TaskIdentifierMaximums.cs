using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.Domain.ViewModels
{
    public class TaskIdentifierMaximums
    {
        public IList<TaskIdentifierModel> Maximums { get; } = new List<TaskIdentifierModel>();

        public TaskIdentifierMaximums()
        {
            Maximums.Add(new TaskIdentifierModel(1, 1, 24));
            Maximums.Add(new TaskIdentifierModel(2, 1, 14));
            Maximums.Add(new TaskIdentifierModel(2, 2, 16));
        }
    }
}
