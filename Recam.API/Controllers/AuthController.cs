using Microsoft.AspNetCore.Mvc;
using Recam.Services.DTOs;
using Recam.Services.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var success = await _authService.RegisterAsync(request);

        if (!success)
        {
            return BadRequest("User registration failed");
        }

        return Ok("User registered successfully");
    }
}