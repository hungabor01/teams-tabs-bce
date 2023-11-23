using Moq;
using TeamsTabsBCE.BusinessLogic.ControllerHandlers;
using TeamsTabsBCE.DatabaseAccess.RepositoryHandlers;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.SoftengDashboard;
using TeamsTabsBCE.Services.ContentCreator;

namespace TeamsTabsBCE.Tests.BusinessLogic.ControllerHandlers
{
    public class SoftengDashboardControllerHandlerTests
    {
        [Fact]
        public async Task GetSoftengDashboardViewModel_AnyCall_ListsHaveCorrectTaskIdentifiersAsync()
        {
            var results = new List<TaskResultModel>();

            var taskIdentifiers = new List<FullTaskIdentifierModel>
            {
                new FullTaskIdentifierModel(new TaskIdentifierModel(1, 1, 1), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(1, 1, 2), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(1, 1, 3), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 1, 1), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 1, 2), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 1, 3), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 1, 4), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 2, 1), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 2, 2), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 2, 3), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 2, 4), null, results),
                new FullTaskIdentifierModel(new TaskIdentifierModel(2, 2, 5), null, results),
            };

            var taskIdentifierRepositoryHandler = new Mock<ITaskIdentifierRepositoryHandler>();
            taskIdentifierRepositoryHandler.Setup(x => x.GetAllTaskIdentifiers())
                .Returns(Task.FromResult<IList<FullTaskIdentifierModel>>(taskIdentifiers));

            var contentCreator = new ContentCreator();

            var controllerHandler = new SoftengDashboardControllerHandler(taskIdentifierRepositoryHandler.Object, contentCreator);
            var result = await controllerHandler.GetSoftengDashboardViewModel();

            Assert.NotNull(result);

            CheckAllTaskIdentifierHasTheCorrectValue(result, 1, 1, 3);
            CheckAllTaskIdentifierHasTheCorrectValue(result, 2, 1, 4);
            CheckAllTaskIdentifierHasTheCorrectValue(result, 2, 2, 5);
        }

        private static void CheckAllTaskIdentifierHasTheCorrectValue(SoftengDashboardViewModel softengDashboardViewModel, int week, int list, int count)
        {
            var dashboardWeek = softengDashboardViewModel.Weeks.Single(x => x.Number == week);
            var dashboardList = dashboardWeek.Lists.Single(x => x.MaxTaskIdentifier.List == list);
            Assert.Equal(count, dashboardList.FullTaskIdentifierModels.Count);
            Assert.All(dashboardList.FullTaskIdentifierModels, x => { Assert.Equal(week, x.Week); Assert.Equal(list, x.List); });
        }
    }
}
