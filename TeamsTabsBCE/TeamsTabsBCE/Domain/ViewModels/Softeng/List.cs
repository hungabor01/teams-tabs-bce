using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.ViewModels.Softeng
{
    public class List
    {
        public string Description { get; }
        public string Title { get; }
        public string Link { get; }
        public TaskIdentifierModel MaxTaskIdentifier { get; }

        public List(string? description, string? title, string link, TaskIdentifierModel maxTaskIdentifier)
        {
            link.ThrowExceptionIfNullOrWhiteSpace(nameof(link));
            maxTaskIdentifier.ThrowExceptionIfNull(nameof(maxTaskIdentifier));

            Description = description ?? string.Empty;
            Title = title ?? string.Empty;
            Link = link;
            MaxTaskIdentifier = maxTaskIdentifier;
        }

        public string GetBaseId()
        {
            return MaxTaskIdentifier.Value[..^MaxTaskIdentifier.Step.ToString().Length];
        }

        public string GetListId()
        {
            return MaxTaskIdentifier.Value[..^(1 + nameof(TaskIdentifierModel.Step).Length + MaxTaskIdentifier.Step.ToString().Length)];
        }
    }
}
