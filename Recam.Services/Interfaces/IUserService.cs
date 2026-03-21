using Recam.Services.DTOs;

namespace Recam.Services.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<bool> ChangePasswordAsync(string userId, ChangePasswordRequest request);
}