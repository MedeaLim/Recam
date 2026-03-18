using Recam.Models.Entities;

namespace Recam.Services.Interfaces;

public interface ICaseContactService
{
    Task AddCaseContactAsync(CaseContact caseContact);

    Task<List<CaseContact>> GetByListingIdAsync(Guid listingId);
}