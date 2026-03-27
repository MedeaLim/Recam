namespace Recam.Services.DTOs.Media;

public class DownloadResult
{
    public Stream FileStream { get; set; } = default!;
    public string ContentType { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
}