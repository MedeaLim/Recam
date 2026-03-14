namespace Recam.Models.Entities;

public class MediaAsset
{
    public Guid Id { get; set; }

    public Guid ListingCaseId { get; set; }

    public string MediaType { get; set; } = string.Empty;

    public string FileUrl { get; set; } = string.Empty;

    public bool IsHero { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}