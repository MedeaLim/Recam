using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Service.DTOs.Media;
using Recam.Service.Interfaces;
using Recam.Services.Interfaces;
using Recam.Services.DTOs.Media;

namespace Recam.Service.Services;

public class MediaService : IMediaService
{
    private readonly IMediaRepository _mediaRepository;
    private readonly IMediaStorageService _storageService;

    private readonly string _baseUrl = "https://localhost:5001";

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
            Url = $"{_baseUrl}/{media.StoragePath}",
            MediaType = media.MediaType.ToString()
        };
    }

    public async Task<List<MediaResponseDto>> GetMediaByListingIdAsync(Guid listingId)
    {
        var mediaList = await _mediaRepository.GetByListingIdAsync(listingId);

        return mediaList
            .Where(m => !m.IsDeleted)
            .Select(m => new MediaResponseDto
            {
                Id = m.Id,
                Url = $"{_baseUrl}/{m.StoragePath}",
                MediaType = m.MediaType.ToString()
            })
            .ToList();
    }

    public async Task<List<MediaResponseDto>> GetAllMediaAsync()
    {
        var mediaList = await _mediaRepository.GetAllAsync();

        return mediaList
            .Where(m => !m.IsDeleted)
            .Select(m => new MediaResponseDto
            {
                Id = m.Id,
                Url = $"{_baseUrl}/{m.StoragePath}",
                MediaType = m.MediaType.ToString()
            })
            .ToList();
    }

    public async Task DeleteMediaAsync(Guid mediaId)
    {
        var media = await _mediaRepository.GetByIdAsync(mediaId);

        if (media == null)
            throw new Exception("Media not found");

        await _mediaRepository.DeleteAsync(media);
    }

    public async Task SelectMediaAsync(Guid listingId, List<Guid> selectedMediaIds)
    {
        var mediaList = await _mediaRepository.GetByListingIdAsync(listingId);

        foreach (var media in mediaList)
        {
            media.IsSelected = selectedMediaIds.Contains(media.Id);
        }

        await _mediaRepository.SaveChangesAsync();
    }

    public async Task SetHeroAsync(Guid mediaId)
    {
        var media = await _mediaRepository.GetByIdAsync(mediaId);

        if (media == null)
            throw new Exception("Media not found");

        var mediaList = await _mediaRepository.GetByListingIdAsync(media.ListingCaseId);

        foreach (var m in mediaList)
        {
            m.IsHero = false;
        }

        media.IsHero = true;
        media.IsSelected = true;

        await _mediaRepository.SaveChangesAsync();
    }

    public async Task<List<MediaResponseDto>> GetFinalMediaAsync(Guid listingId)
    {
        var mediaList = await _mediaRepository.GetByListingIdAsync(listingId);

        return mediaList
            .Where(m => m.IsSelected && !m.IsDeleted)
            .Select(m => new MediaResponseDto
            {
                Id = m.Id,
                Url = $"{_baseUrl}/{m.StoragePath}",
                MediaType = m.MediaType.ToString()
            })
            .ToList();
    }

    // ✅ 下载单个媒体（RECAM-91）
    public async Task<DownloadResult> GetMediaDownloadAsync(Guid mediaId)
    {
        var media = await _mediaRepository.GetByIdAsync(mediaId);

        if (media == null)
            throw new Exception("Media not found");

        var stream = await _storageService.GetFileStreamAsync(media.StoragePath);

        return new DownloadResult
        {
            FileStream = stream,
            ContentType = media.ContentType,
            FileName = media.OriginalFileName
        };
    }

    public async Task<DownloadResult> GetListingZipAsync(Guid listingId)
    {
    var mediaList = await _mediaRepository.GetByListingIdAsync(listingId);

    if (mediaList == null || !mediaList.Any())
        throw new Exception("No media found for this listing");

    var memoryStream = new MemoryStream();

    using (var zip = new System.IO.Compression.ZipArchive(memoryStream, System.IO.Compression.ZipArchiveMode.Create, true))
    {
        foreach (var media in mediaList.Where(m => !m.IsDeleted))
        {
            var fileStream = await _storageService.GetFileStreamAsync(media.StoragePath);

            var entry = zip.CreateEntry(media.OriginalFileName);

            using var entryStream = entry.Open();
            await fileStream.CopyToAsync(entryStream);
        }
    }

    memoryStream.Position = 0;

    return new DownloadResult
    {
        FileStream = memoryStream,
        ContentType = "application/zip",
        FileName = $"listing-{listingId}.zip"
    };
    }
}