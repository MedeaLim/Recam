using Recam.Models.Enums;

namespace Recam.Service.DTOs.Media;

public class UploadMediaRequestDto
{
    public Stream FileStream { get; set; }

    public string FileName { get; set; }

    public string ContentType { get; set; }

    public MediaType MediaType { get; set; }

    public bool IsHero { get; set; }
}