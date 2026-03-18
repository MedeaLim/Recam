using Microsoft.AspNetCore.Mvc;
using Recam.Models.Entities;
using Recam.Services.DTOs;
using Recam.Services.Interfaces;

namespace Recam.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CaseContactController : ControllerBase
{
    private readonly ICaseContactService _caseContactService;

    public CaseContactController(ICaseContactService caseContactService)
    {
        _caseContactService = caseContactService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCaseContact(CreateCaseContactDto dto)
    {
        var caseContact = new CaseContact
        {
            ListingId = dto.ListingId,
            AgentId = dto.AgentId,
            Name = dto.Name,
            Phone = dto.Phone,
            Email = dto.Email,
            Agency = dto.Agency,
            PhotoUrl = dto.PhotoUrl
        };

        await _caseContactService.AddCaseContactAsync(caseContact);

        return Ok("Case contact added successfully");
    }

    [HttpGet("{listingId}")]
    public async Task<IActionResult> GetCaseContacts(Guid listingId)
    {
        var contacts = await _caseContactService.GetByListingIdAsync(listingId);

        return Ok(contacts);
    }
}