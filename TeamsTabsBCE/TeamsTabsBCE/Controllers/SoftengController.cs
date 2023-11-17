using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.Domain.Models;

namespace TeamsTabsBCE.Controllers
{
    public class SoftengController : Controller
    {
        private readonly ISoftengControllerHandler _controllerHandler;

        public SoftengController(ISoftengControllerHandler softengControllerHandler)
        {
            _controllerHandler = softengControllerHandler;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetTaskResults()
        {
            var userEmail = GetUserEmail();
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                return Unauthorized("Not a valid email address.");
            }

            var taskResults = await _controllerHandler.GetTaskResultsForUser(userEmail);
            return Ok(taskResults);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StoreTaskResult([FromBody] string data)
        {
            var userEmail = GetUserEmail();
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                return Unauthorized("Not a valid email address.");
            }

            var taskResultModel = new TaskResultModel(userEmail, data);
            await _controllerHandler.StoreTaskResult(taskResultModel);
            return Ok();
        }

        private string? GetUserEmail()
        {
            return HttpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
        }
    }
}