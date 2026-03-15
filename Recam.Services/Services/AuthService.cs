using Microsoft.AspNetCore.Identity;
using Recam.Models.Entities;
using Recam.Services.DTOs;
using Recam.Services.Interfaces;
using AutoMapper;

namespace Recam.Services.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        JwtTokenService jwtTokenService,
        IMapper mapper)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
        _mapper = mapper;
    }

    // Register new user
    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return false;

        // Assign default role
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

        return await _jwtTokenService.GenerateToken(user);
    }
}