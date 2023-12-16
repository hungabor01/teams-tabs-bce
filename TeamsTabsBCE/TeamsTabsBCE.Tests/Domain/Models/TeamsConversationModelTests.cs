using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.Tests.Domain.Models
{
    public class TeamsConversationModelTests
    {
        [Theory]
        [InlineData("12X45", 1, 2, 3)]
        [InlineData("1234X", 1, 2, 3)]
        public void Constructor_InvalidConversationId_ThrowArgumentException(string conversationId, int week, int list, int step)
        {
            Assert.Throws<ArgumentException>(() => new TeamsConversationModel(conversationId, new TaskIdentifierModel(week, list, step)));
        }

        [Fact]
        public void Constructor_ValidConversationId_ReturnInstance()
        {
            var conversationId = "12345";
            var model = new TeamsConversationModel(conversationId, new TaskIdentifierModel(1, 2, 3));

            Assert.NotNull(model);
            Assert.Equal(conversationId, model.ConversationId);
            Assert.Equal("week1-list2-step3", model.TaskIdentifierModel.Value);
        }

        [Theory]
        [InlineData("week1-list2-step3 12X45")]
        [InlineData("week1-list2-step3 1234X")]
        [InlineData("week-list2-step3 12345")]
        [InlineData("12345 week1-list2-step3")]
        [InlineData("week1-list2-step3:12345")]
        [InlineData("week1-list2-step3-12345")]
        [InlineData("week1-list2-step3/12345")]
        [InlineData("week1-list2-step3  12345")]
        public void Constructor_InvalidData_ThrowArgumentException(string data)
        {
            Assert.Throws<ArgumentException>(() => new TeamsConversationModel(data));
        }

        [Fact]
        public void Constructor_ValidData_ReturnInstance()
        {
            var taskIdentifierModel = new TaskIdentifierModel(1, 2, 3);
            var conversationId = "12345";
            var model = new TeamsConversationModel(taskIdentifierModel.Value + " " + conversationId);

            Assert.NotNull(model);
            Assert.Equal(conversationId, model.ConversationId);
            Assert.Equal(taskIdentifierModel.Value, model.TaskIdentifierModel.Value);
        }
    }
}
