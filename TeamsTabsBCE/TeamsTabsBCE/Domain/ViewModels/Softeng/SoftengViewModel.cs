using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.ViewModels.Softeng
{
    public class SoftengViewModel
    {
        public string Title { get; }
        public IList<Week> Weeks { get; }

        public SoftengViewModel(string title, IList<Week> weeks)
        {
            title.ThrowExceptionIfNullOrWhiteSpace(nameof(title));
            weeks.ThrowExceptionIfNull(nameof(weeks));

            Title = title;
            Weeks = weeks;
        }
    }
}
