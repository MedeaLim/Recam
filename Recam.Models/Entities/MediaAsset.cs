using Recam.Models.Entities;
using Recam.Models.Enums;
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

    public bool IsSelected { get; set; } = false; // ⭐ 新增

    public bool IsHero { get; set; }

    public bool IsDeleted { get; set; } = false;

    public DateTime CreatedAt { get; set; }

    public ListingCase ListingCase { get; set; }
}