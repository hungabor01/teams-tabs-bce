using TeamsTabsBCE.Domain.ViewModels.Softeng;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.ViewModels.SoftengDashboard
{
    public class SoftengDashboardViewModel
    {
        public string Title { get; }
        public IList<DashboardWeek> Weeks { get; } = new List<DashboardWeek>();

        public SoftengDashboardViewModel(SoftengViewModel softengViewModel)
        {
            softengViewModel.ThrowExceptionIfNull(nameof(softengViewModel));

            Title = softengViewModel.Title;

            foreach (var week in softengViewModel.Weeks)
            {
                Weeks.Add(new DashboardWeek(week));
            }
        }
    }
}
