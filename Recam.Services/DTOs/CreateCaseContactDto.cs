namespace Recam.Services.DTOs;

public class CreateCaseContactDto
{
    public Guid ListingId { get; set; }

    public string AgentId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Agency { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }
}