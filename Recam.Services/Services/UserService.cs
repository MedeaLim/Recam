using Microsoft.AspNetCore.Identity;
using Recam.Models.Entities;
using Recam.Services.DTOs;
using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = _userManager.Users.ToList();

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email!,
            Role = "", // 你之前怎么处理 role 就保持原样
        }).ToList();
    }

    public async Task<bool> ChangePasswordAsync(string userId, ChangePasswordRequest request)
    {
        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
            return false;

        var result = await _userManager.ChangePasswordAsync(
            user,
            request.CurrentPassword,
            request.NewPassword
        );

        return result.Succeeded;
    }
}