using Microsoft.AspNetCore.Identity;
using Recam.Models.Entities;
using Recam.Services.DTOs;
using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtTokenService _jwtTokenService;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        JwtTokenService jwtTokenService)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }

    // Register new user
    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var user = new ApplicationUser
        {
            UserName = request.Email,
            Email = request.Email
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return false;

        // Assign default role to new user
        await _userManager.AddToRoleAsync(user, "Agent");

        return true;
    }

    // Login user
    public async Task<string?> LoginAsync(LoginRequest request)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);

        if (user == null)
            return null;

        var validPassword = await _userManager.CheckPasswordAsync(user, request.Password);

        if (!validPassword)
            return null;

        // Generate JWT token
        return await _jwtTokenService.GenerateToken(user);
    }
}