using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Recam.Services.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IAuthService _authService;

    public UsersController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetCurrentUser()
    {
        var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

        if (userId == null)
            return Unauthorized();

        var result = await _authService.GetCurrentUserWithListingsAsync(userId);

        return Ok(result);
    }
}