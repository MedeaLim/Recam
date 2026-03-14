namespace Recam.Models.Entities;

public class StatusHistory
{
    public Guid Id { get; set; }

    public Guid ListingCaseId { get; set; }

    public string OldStatus { get; set; } = string.Empty;

    public string NewStatus { get; set; } = string.Empty;

    public Guid ChangedByUserId { get; set; }

    public DateTime ChangedAt { get; set; } = DateTime.UtcNow;
}