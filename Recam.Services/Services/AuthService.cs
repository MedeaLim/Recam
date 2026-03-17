using Microsoft.AspNetCore.Identity;
using Recam.Models.Entities;
using Recam.Services.DTOs;
using Recam.Services.Interfaces;
using AutoMapper;
using Recam.Repository.Interfaces;

namespace Recam.Services.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly JwtTokenService _jwtTokenService;
    private readonly IMapper _mapper;
    private readonly IListingRepository _listingRepository;

    public AuthService(
        UserManager<ApplicationUser> userManager,
        JwtTokenService jwtTokenService,
        IMapper mapper,
        IListingRepository listingRepository)
    {
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
        _mapper = mapper;
        _listingRepository = listingRepository;
    }

    // Register new user
    public async Task<bool> RegisterAsync(RegisterRequest request)
    {
        var user = _mapper.Map<ApplicationUser>(request);

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return false;

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

    // ⭐ 新方法
    public async Task<CurrentUserResponseDto> GetCurrentUserWithListingsAsync(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            throw new Exception("User not found");

        var roles = await _userManager.GetRolesAsync(user);

        var listings = await _listingRepository.GetByAgentIdAsync(userId);

        return new CurrentUserResponseDto
        {
            UserId = user.Id,
            Email = user.Email,
            Role = roles.FirstOrDefault(),
            ListingIds = listings.Select(l => l.Id).ToList()
        };
    }
}