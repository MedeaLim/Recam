using Recam.Models.Enums;

namespace Recam.Service.DTOs.Media;

public class UploadMediaRequestDto
{
    public Stream FileStream { get; set; } = default!;

    public string FileName { get; set; } = string.Empty;

    public string ContentType { get; set; } = string.Empty;

    public MediaType MediaType { get; set; }

    public bool IsHero { get; set; }
}