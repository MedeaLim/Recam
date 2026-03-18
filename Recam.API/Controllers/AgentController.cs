using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recam.Services.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/agent")]
[Authorize(Roles = "Agent,Admin")]
public class AgentController : ControllerBase
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }

    [HttpGet("profile")]
    public IActionResult GetAgentProfile()
    {
        return Ok("Agent access granted");
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchAgent([FromQuery] string email)
    {
        var agent = await _agentService.GetByEmailAsync(email);

        if (agent == null)
        {
            return NotFound("Agent not found");
        }

        return Ok(agent);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAgents()
    {
        var agents = await _agentService.GetAllAsync();

        return Ok(agents);
    }
}