using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recam.Services.Interfaces;
using Recam.Services.DTOs.Agent;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/agent")]
[Authorize(Roles = "Admin")]
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

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateAgent(CreateAgentRequest request)
    {
        var agentId = await _agentService.CreateAgentAsync(request);

        return Ok(new
        {
            message = "Agent created successfully",
            agentId = agentId
        });
    }
}