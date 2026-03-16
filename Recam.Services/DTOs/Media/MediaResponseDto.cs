using Recam.Models.Enums;

namespace Recam.Service.DTOs.Media;

public class MediaResponseDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; }

    public MediaType MediaType { get; set; }

    public string StoragePath { get; set; }
}