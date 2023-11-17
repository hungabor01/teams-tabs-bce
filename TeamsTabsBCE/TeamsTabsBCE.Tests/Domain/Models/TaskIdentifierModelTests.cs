using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.Tests.Domain.Models
{
    public class TaskIdentifierModelTests
    {
        [Theory]
        [InlineData(0, 2, 3)]
        [InlineData(1, 0, 3)]
        [InlineData(1, 2, 0)]
        [InlineData(-1, 2, 3)]
        [InlineData(1, -2, 3)]
        [InlineData(1, 2, -3)]
        public void Constructor_InvalidValues_ThrowArgumentException(int week, int list, int step)
        {
            Assert.Throws<ArgumentException>(() => new TaskIdentifierModel(week, list, step));
        }

        [Fact]
        public void Constructor_ValidValues_ReturnInstance()
        {
            var model = new TaskIdentifierModel(1, 2, 3);

            Assert.NotNull(model);
            Assert.Equal("week1-list2-step3", model.Value);
        }

        [Theory]
        [InlineData("aweek1-list2-step6")]
        [InlineData("week1-list2-step6a")]
        [InlineData("week1-list2--step6")]
        [InlineData("week-1-list2-step6")]
        [InlineData("week-list2-step6")]
        [InlineData("week1.2-list2-step6")]
        [InlineData("week1-list2,5-step6")]
        [InlineData("week0-list2-step3")]
        [InlineData("week1-list0-step3")]
        [InlineData("week1-list2-step0")]
        public void Constructor_NotValidValue_ThrowArgumentException(string value)
        {
            Assert.Throws<ArgumentException>(() => new TaskIdentifierModel(value));
        }

        [Theory]
        [InlineData("week1-list2-step6", 1, 2, 6)]
        [InlineData("week12-list22-step32", 12, 22, 32)]
        public void Constructor_ValidValue_ReturnInstance(string value, int week, int list, int step)
        {
            var model = new TaskIdentifierModel(value);

            Assert.NotNull(model);
            Assert.Equal(week, model.Week);
            Assert.Equal(list, model.List);
            Assert.Equal(step, model.Step);
        }
    }
}
