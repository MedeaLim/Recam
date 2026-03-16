using Recam.Models.Enums;

namespace Recam.Models.Entities;

public class MediaAsset
{
    public Guid Id { get; set; }

    public Guid ListingCaseId { get; set; }

    public string FileName { get; set; }

    public string OriginalFileName { get; set; }

    public string StoragePath { get; set; }

    public string ContentType { get; set; }

    public long FileSize { get; set; }

    public MediaType MediaType { get; set; }

    public bool IsHero { get; set; }

    public bool IsDeleted { get; set; } = false;   // ⭐ 必须有这一行

    public DateTime CreatedAt { get; set; }

    public ListingCase ListingCase { get; set; }
}