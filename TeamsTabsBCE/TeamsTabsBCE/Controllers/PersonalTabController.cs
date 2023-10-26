using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class PersonalTabController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Message from PersonalTabController.";
            return View();
        }
    }
}