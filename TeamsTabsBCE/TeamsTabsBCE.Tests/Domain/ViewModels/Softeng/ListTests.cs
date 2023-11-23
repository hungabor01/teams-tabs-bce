using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.Softeng;

namespace TeamsTabsBCE.Tests.Domain.ViewModels.Softeng
{
    public class ListTests
    {
        [Fact]
        public void GetBaseId_AnyCall_ReturnValueWithoutStep()
        {
            var list = new List(null, null, "link", new TaskIdentifierModel(1, 2, 1));
            var result = list.GetBaseId();
            Assert.Equal("week1-list2-step", result);
        }

        [Fact]
        public void GetListId_AnyCall_ReturnValueWithoutStepString()
        {
            var list = new List(null, null, "link", new TaskIdentifierModel(1, 2, 1));
            var result = list.GetListId();
            Assert.Equal("week1-list2", result);
        }
    }
}
