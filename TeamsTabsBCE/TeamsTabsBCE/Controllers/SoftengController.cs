using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class SoftengController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}