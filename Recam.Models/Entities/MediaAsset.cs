using Recam.Models.Enums;

namespace Recam.Models.Entities;

public class MediaAsset
{
    public Guid Id { get; set; }

    public Guid ListingId { get; set; }

    public ListingCase ListingCase { get; set; }

    public string FileName { get; set; } = string.Empty;

    public string OriginalFileName { get; set; } = string.Empty;

    public string StoragePath { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public long FileSize { get; set; }

    public MediaType MediaType { get; set; }

    public bool IsHero { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public bool IsDeleted { get; set; }
}