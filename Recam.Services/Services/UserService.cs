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

        var result = new List<UserDto>();

        foreach (var user in users)
        {
            var roles = await _userManager.GetRolesAsync(user);

            result.Add(new UserDto
            {
                Id = user.Id,
                Email = user.Email!,
                Role = roles.FirstOrDefault() ?? "None"
            });
        }

        return result;
    }
}