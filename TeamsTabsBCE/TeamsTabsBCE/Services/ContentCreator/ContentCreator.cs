using System.Runtime.CompilerServices;
using TeamsTabsBCE.BusinessLogic.Interfaces.Services;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Domain.ViewModels.Softeng;
using TeamsTabsBCE.Domain.ViewModels.SoftengDashboard;

[assembly: InternalsVisibleTo("TeamsTabsBCE.Tests")]
namespace TeamsTabsBCE.Services.ContentCreator
{
    internal class ContentCreator : IContentCreator
    {
        public SoftengViewModel CreateSoftengContent()
        {
            var list11 = new List(
                "In memory adatbázisok, adatok mentése fájlba illetve visszatöltése fájlból. Adatkötött vezérlők használata",
                "Gyakorlati feladatsor:",
                "In-memory adatbázis",
                new TaskIdentifierModel(1, 1, 24));
            var week1 = new Week(1, new[] { list11 });

            var list21 = new List(
                "",
                "2a. gyakorlati feladatsor:",
                "Távoli SQL adatbázis elérése C# alkalmazásból",
                new TaskIdentifierModel(2, 1, 14));
            var list22 = new List(
                "",
                "2b. gyakorlati feladatsor:",
                "Lokális SQL adatbázis használata",
                new TaskIdentifierModel(2, 2, 16));
            var week2 = new Week(2, new[] { list21, list22 });

            var weeks = new List<Week>
            {
                week1,
                week2
            };

            return new SoftengViewModel("Software Engineering (2023/2024/1)", weeks);
        }

        public SoftengDashboardViewModel CreateSoftengDashboardContent()
        {
            var softengViewModel = CreateSoftengContent();
            return new SoftengDashboardViewModel(softengViewModel);
        }
    }
}
