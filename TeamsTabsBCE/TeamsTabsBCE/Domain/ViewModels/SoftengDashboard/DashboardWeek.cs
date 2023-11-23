using TeamsTabsBCE.Domain.ViewModels.Softeng;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.ViewModels.SoftengDashboard
{
    public class DashboardWeek
    {
        public int Number { get; }
        public IList<DashboardList> Lists { get; } = new List<DashboardList>();

        public DashboardWeek(Week week)
        {
            week.ThrowExceptionIfNull(nameof(week));

            Number = week.Number;

            foreach (var list in week.Lists)
            {
                Lists.Add(new DashboardList(list));
            }
        }
    }
}
