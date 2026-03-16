using Microsoft.AspNetCore.Mvc;
using Recam.Models.Enums;
using Recam.Service.DTOs.Media;
using Recam.Service.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
[Route("listings/{listingId}/media")]
public class MediaController : ControllerBase
{
    private readonly IMediaService _mediaService;

    public MediaController(IMediaService mediaService)
    {
        _mediaService = mediaService;
    }

    [HttpPost]
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
}