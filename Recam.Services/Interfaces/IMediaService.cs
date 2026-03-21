using Recam.Service.DTOs.Media;

namespace Recam.Service.Interfaces;

public interface IMediaService
{
    Task<MediaResponseDto> UploadMediaAsync(Guid listingId, UploadMediaRequestDto request);

    Task<List<MediaResponseDto>> GetMediaByListingIdAsync(Guid listingId);

    Task<List<MediaResponseDto>> GetAllMediaAsync();

    Task DeleteMediaAsync(Guid mediaId);

    Task SelectMediaAsync(Guid listingId, List<Guid> selectedMediaIds);
    Task SetHeroAsync(Guid mediaId);
    
}