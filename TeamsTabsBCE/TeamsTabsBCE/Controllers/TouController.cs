using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class TouController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Message = "Add your Terms of Use statement here...";
            return View();
        }
    }
}