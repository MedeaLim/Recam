using Microsoft.AspNetCore.Mvc;
using Recam.Models.Enums;
using Recam.Service.DTOs.Media;
using Recam.Service.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
public class MediaController : ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpPost("listings/{listingId}/media")]
    public async Task<IActionResult> UploadMedia(
        Guid listingId,
        IFormFile file,
        MediaType mediaType,
        bool isHero)
    {
        var dto = new UploadMediaRequestDto
        {
            FileStream = file.OpenReadStream(),
            FileName = file.FileName,
            ContentType = file.ContentType,
            MediaType = mediaType,
            IsHero = isHero
        };

        var result = await _mediaService.UploadMediaAsync(listingId, dto);

        return Ok(result);
    }

    [HttpGet("listings/{listingId}/media")]
    public async Task<IActionResult> GetListingMedia(Guid listingId)
    {
        var media = await _mediaService.GetMediaByListingIdAsync(listingId);

        return Ok(media);
    }

    [HttpGet("media")]
    public async Task<IActionResult> GetAllMedia()
    {
        var media = await _mediaService.GetAllMediaAsync();

        return Ok(media);
    }

    [HttpDelete("media/{id}")]
    public async Task<IActionResult> DeleteMedia(Guid id)
    {
        await _mediaService.DeleteMediaAsync(id);

        return NoContent();
    }
}