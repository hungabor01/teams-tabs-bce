using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeamsTabsBCE.Controllers
{
    public class SoftengController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult GetUserEmail()
        {
            var email = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
            return Ok(email);
        }
    }
}