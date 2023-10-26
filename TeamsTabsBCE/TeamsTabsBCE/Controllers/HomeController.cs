using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Message from HomeController.";
            return View();
        }
    }
}