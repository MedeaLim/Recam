using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/agent")]
[Authorize(Roles = "Agent,Admin")]
public class AgentController : ControllerBase
{
    [HttpGet("profile")]
    public IActionResult GetAgentProfile()
    {
        return Ok("Agent access granted");
    }
}