namespace Recam.Service.DTOs.Media;

public class MediaResponseDto
{
    public Guid Id { get; set; }

    public string Url { get; set; } = default!;

    public string MediaType { get; set; } = default!;
}