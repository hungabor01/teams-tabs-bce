using System.Text.RegularExpressions;
using TeamsTabsBCE.Database.Core.Entities;
using TeamsTabsBCE.Shared.ExtensionMethods;

namespace TeamsTabsBCE.Domain.Models
{
    public class TaskIdentifierModel : IModel
    {
        private const string _delimiter = "-";

        public int Week { get; }
        public int List { get; }
        public int Step { get; }
        public string Value { get; }

        public TaskIdentifierModel(int week, int list, int step)
        {
            Week = week;
            List = list;
            Step = step;

            Value = $"{nameof(Week).ToLower()}{Week}" +
                $"{_delimiter}" +
                $"{nameof(List).ToLower()}{List}" +
                $"{_delimiter}" +
                $"{nameof(Step).ToLower()}{Step}";

            VerifyProperties();
        }

        public TaskIdentifierModel(string value)
        {
            value.ThrowExceptionIfNullOrWhiteSpace(nameof(value));

            Value = value;

            (var week, var list, var step) = ParseTaskIdentifierValue(Value);
            Week = week;
            List = list;
            Step = step;

            VerifyProperties();
        }

        private static Tuple<int, int, int> ParseTaskIdentifierValue(string value)
        {
            var regex = new Regex($"^{nameof(TaskIdentifier.Week).ToLower()}(\\d+)" +
                $"{_delimiter}" +
                $"{nameof(TaskIdentifier.List).ToLower()}(\\d+)" +
                $"{_delimiter}" +
                $"{nameof(TaskIdentifier.Step).ToLower()}(\\d+)$");

            var match = regex.Match(value);
            if (!match.Success)
            {
                throw new ArgumentException($"Invalid task value: {value}.");
            }

            int week = int.Parse(match.Groups[1].Value);
            int list = int.Parse(match.Groups[2].Value);
            int step = int.Parse(match.Groups[3].Value);

            return Tuple.Create(week, list, step);
        }

        private void VerifyProperties()
        {
            if (Week <= 0)
            {
                throw new ArgumentException($"{nameof(Week)} should be greater than 0, but it is {Week}");
            }

            if (List <= 0)
            {
                throw new ArgumentException($"{nameof(List)} should be greater than 0, but it is {List}");
            }

            if (Step <= 0)
            {
                throw new ArgumentException($"{nameof(Step)} should be greater than 0, but it is {Step}");
            }
        }
    }
}
