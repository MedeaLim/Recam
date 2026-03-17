using Recam.Services.DTOs;

namespace Recam.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterRequest request);
    Task<string?> LoginAsync(LoginRequest request);
    Task<CurrentUserResponseDto> GetCurrentUserWithListingsAsync(string userId);
    
}