using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.Tests.Domain.Models
{
    public class TaskResultModelTests
    {
        [Theory]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(-2)]
        [InlineData(-10)]
        public void Constructor_InvalidResult_ThrowArgumentException(int result)
        {
            Assert.Throws<ArgumentException>(() => new TaskResultModel("userEmail", new TaskIdentifierModel(1, 2, 3), result));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Constructor_ValidResult_ReturnInstance(int result)
        {
            var model = new TaskResultModel("userEmail", new TaskIdentifierModel(1, 2, 3), result);

            Assert.NotNull(model);
        }

        [Theory]
        [InlineData("alma")]
        [InlineData("alma 1 barack")]
        [InlineData("alma 1")]
        [InlineData("week1-list2-step3 alma")]
        [InlineData("week1-list2-step3 1.2")]
        [InlineData("week1-list2-step3 1,2")]
        [InlineData("week1-list2-step3 2")]
        [InlineData("week1-list2-step3 -2")]
        public void Constructor_InvalidData_ThrowArgumentException(string data)
        {
            Assert.Throws<ArgumentException>(() => new TaskResultModel("userEmail", data));
        }

        [Theory]
        [InlineData("week1-list2-step3 1", 1)]
        [InlineData("week1-list2-step3 0", 0)]
        [InlineData("week1-list2-step3 -1", -1)]
        public void Constructor_InvalidData_ReturnInstance(string data, int result)
        {
            var model = new TaskResultModel("userEmail", data);

            Assert.NotNull(model);
            Assert.NotNull(model.TaskIdentifierModel);
            Assert.Equal(result, model.Result);
        }
    }
}
