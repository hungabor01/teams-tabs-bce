using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TeamsTabsBCE.BusinessLogic.Interfaces.ControllerHandlers;
using TeamsTabsBCE.Domain.Models;
using TeamsTabsBCE.Hubs;

namespace TeamsTabsBCE.Controllers
{
    public class SoftengController : Controller
    {
        private readonly IHubContext<SoftengDashboardHub> _softengDashboardHub;
        private readonly ISoftengControllerHandler _controllerHandler;

        public SoftengController(
            IHubContext<SoftengDashboardHub> softengDashboardHub,
            ISoftengControllerHandler softengControllerHandler)
        {
            _softengDashboardHub = softengDashboardHub;
            _controllerHandler = softengControllerHandler;
        }

        public IActionResult Index()
        {
            var model = _controllerHandler.GetViewModel();
            return base.View(model);
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
            if (string.IsNullOrWhiteSpace(data))
            {
                return BadRequest($"Empty body for {nameof(StoreTaskResult)}.");
            }

            var userEmail = GetUserEmail();
            if (string.IsNullOrWhiteSpace(userEmail))
            {
                return Unauthorized("Not a valid email address.");
            }

            var taskResultModel = new TaskResultModel(userEmail, data);
            await _controllerHandler.StoreTaskResult(taskResultModel);

            await _softengDashboardHub.Clients.All.SendAsync(SoftengDashboardHub.RefreshCommand);

            return Ok();
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetConversationId(string taskIdentifierValue)
        {
            if (string.IsNullOrWhiteSpace(taskIdentifierValue))
            {
                return BadRequest($"Empty parameter for {nameof(GetConversationId)}.");
            }

            var taskIdentifierModel = new TaskIdentifierModel(taskIdentifierValue);
            var teamsConversationId = await _controllerHandler.GetTeamsConversationId(taskIdentifierModel);
            return Ok(teamsConversationId);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> StoreConversation([FromBody] string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                return BadRequest($"Empty body for {nameof(StoreConversation)}.");
            }

            var teamsConversationModel = new TeamsConversationModel(data);
            await _controllerHandler.StoreTeamsConversation(teamsConversationModel);

            await _softengDashboardHub.Clients.All.SendAsync(SoftengDashboardHub.RefreshCommand);

            return Ok();
        }

        private string? GetUserEmail()
        {
            return HttpContext.User.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
        }
    }
}