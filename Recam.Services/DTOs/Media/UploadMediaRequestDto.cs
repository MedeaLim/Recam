using Recam.Models.Enums;

namespace Recam.Service.DTOs.Media;

public class UploadMediaRequestDto
{
    public Stream FileStream { get; set; } = default!;

    public string FileName { get; set; } = default!;

    public string ContentType { get; set; } = default!;

    public MediaType MediaType { get; set; }

    public bool IsHero { get; set; }
}