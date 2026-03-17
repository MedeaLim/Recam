namespace Recam.Services.DTOs;

public class CurrentUserResponseDto
{
    public string UserId { get; set; }

    public string Email { get; set; }

    public string Role { get; set; }

    public List<Guid> ListingIds { get; set; }
}