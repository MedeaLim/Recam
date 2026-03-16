using Recam.Service.DTOs.Media;

namespace Recam.Service.Interfaces;

public interface IMediaService
{
    Task<MediaResponseDto> UploadMediaAsync(Guid listingId, UploadMediaRequestDto request);
}