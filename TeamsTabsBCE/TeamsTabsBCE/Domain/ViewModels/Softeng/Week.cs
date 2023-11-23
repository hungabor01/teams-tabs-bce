using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.ViewModels.Softeng
{
    public class Week
    {
        public int Number { get; }
        public IList<List> Lists { get; }

        public Week(int number, IList<List> lists)
        {
            lists.ThrowExceptionIfNull(nameof(lists));

            Number = number;
            Lists = lists;
        }
    }
}
