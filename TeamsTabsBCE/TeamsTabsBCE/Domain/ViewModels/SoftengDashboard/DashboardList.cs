using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.Softeng;

namespace TeamsTabsBCE.Domain.ViewModels.SoftengDashboard
{
    public class DashboardList : List
    {
        public IList<FullTaskIdentifierModel> FullTaskIdentifierModels { get; } = new List<FullTaskIdentifierModel>();

        public DashboardList(List list)
            : base(list.Description, list.Title, list.Link, list.MaxTaskIdentifier)
        {
        }
    }
}
