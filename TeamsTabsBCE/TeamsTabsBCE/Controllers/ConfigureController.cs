using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.Controllers
{
    public class ConfigureController : Controller
    {
        private readonly IConfigureControllerHandler _configureControllerHandler;

        public ConfigureController(IConfigureControllerHandler configureControllerHandler)
        {
            _configureControllerHandler = configureControllerHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StoreSettings([FromBody] JsonElement data)
        {
            var settingsModel = new SettingsModel(data);
            await _configureControllerHandler.StoreSettings(settingsModel);
            return Ok();
        }
    }
}