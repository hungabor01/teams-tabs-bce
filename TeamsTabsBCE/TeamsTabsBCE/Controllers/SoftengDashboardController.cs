using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;

namespace TeamsTabsBCE.Controllers
{
    public class SoftengDashboardController : Controller
    {
        private readonly ISoftengDashboardControllerHandler _controllerHandler;

        public SoftengDashboardController(ISoftengDashboardControllerHandler handler)
        {
            _controllerHandler = handler;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await _controllerHandler.GetSoftengDashboardViewModel();
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetSettings()
        {
            var settings = await _controllerHandler.GetSettings();
            return Ok(settings);
        }
    }
}
