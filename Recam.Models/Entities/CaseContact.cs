namespace Recam.Models.Entities;

public class CaseContact
{
    public Guid Id { get; set; }

    public Guid ListingId { get; set; }

    public string AgentId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Agency { get; set; } = string.Empty;

    public string? PhotoUrl { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public ListingCase ListingCase { get; set; } = null!;
}