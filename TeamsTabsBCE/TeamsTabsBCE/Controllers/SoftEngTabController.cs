using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class SoftEngTabController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Message from PersonalTabController.";
            return View();
        }
    }
}