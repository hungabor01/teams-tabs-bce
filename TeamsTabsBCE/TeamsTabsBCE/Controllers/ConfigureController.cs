using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class ConfigureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}