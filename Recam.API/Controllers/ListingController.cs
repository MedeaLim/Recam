using Microsoft.AspNetCore.Mvc;
using Recam.Models.Entities;
using Recam.Services.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ListingController : ControllerBase
{
    private readonly IListingService _listingService;

    public ListingController(IListingService listingService)
    {
        _listingService = listingService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        string? status,
        string? keyword,
        string? propertyType,
        int page = 1,
        int pageSize = 10)
    {
        var listings = await _listingService.GetAllListingsAsync(
            status,
            keyword,
            propertyType,
            page,
            pageSize);

        return Ok(listings);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var listing = await _listingService.GetListingByIdAsync(id);

        if (listing == null)
            return NotFound();

        return Ok(listing);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ListingCase listing)
    {
        await _listingService.CreateListingAsync(listing);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ListingCase listing)
    {
        if (id != listing.Id)
            return BadRequest();

        await _listingService.UpdateListingAsync(listing);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _listingService.DeleteListingAsync(id);
        return Ok();
    }


    [HttpPatch("{id}/status")]
    public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] string status)
    {
        await _listingService.UpdateStatusAsync(id, status);
        return Ok();
    }
}