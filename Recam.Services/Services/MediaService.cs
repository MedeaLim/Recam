using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Service.DTOs.Media;
using Recam.Service.Interfaces;
using Recam.Services.Interfaces;

namespace Recam.Service.Services;

public class MediaService : IMediaService
{
    private readonly IMediaRepository _mediaRepository;
    private readonly IMediaStorageService _storageService;

    public MediaService(
        IMediaRepository mediaRepository,
        IMediaStorageService storageService)
    {
        _mediaRepository = mediaRepository;
        _storageService = storageService;
    }

    public async Task<MediaResponseDto> UploadMediaAsync(Guid listingId, UploadMediaRequestDto request)
    {
        var fileName = Guid.NewGuid() + Path.GetExtension(request.FileName);

        var storagePath = await _storageService.UploadAsync(
            request.FileStream,
            fileName
        );

        var media = new MediaAsset
        {
            Id = Guid.NewGuid(),
            ListingCaseId = listingId,
            FileName = fileName,
            OriginalFileName = request.FileName,
            StoragePath = storagePath,
            ContentType = request.ContentType,
            FileSize = request.FileStream.Length,
            MediaType = request.MediaType,
            IsHero = request.IsHero,
            CreatedAt = DateTime.UtcNow
        };

        await _mediaRepository.AddAsync(media);

        return new MediaResponseDto
        {
            Id = media.Id,
            FileName = media.FileName,
            MediaType = media.MediaType,
            StoragePath = media.StoragePath
        };
    }
}