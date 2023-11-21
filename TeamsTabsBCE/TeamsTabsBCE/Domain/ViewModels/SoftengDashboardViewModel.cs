using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.ViewModels
{
    public class SoftengDashboardViewModel
    {
        public TaskIdentifierMaximums TaskIdentifierMaximums { get; } = new TaskIdentifierMaximums();
        public IList<FullTaskIdentifierModel> FullTaskIdentifierModels { get; }

        public SoftengDashboardViewModel(IList<FullTaskIdentifierModel> fullTaskIdentifierModels)
        {
            fullTaskIdentifierModels.ThrowExceptionIfNull(nameof(fullTaskIdentifierModels));

            FullTaskIdentifierModels = fullTaskIdentifierModels;
        }
    }
}
