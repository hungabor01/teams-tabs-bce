using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Add your privacy statement here...";
            return View();
        }
    }
}