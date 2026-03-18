using Recam.Models.Entities;

namespace Recam.Repository.Interfaces;

public interface ICaseContactRepository
{
    Task AddAsync(CaseContact caseContact);

    Task<List<CaseContact>> GetByListingIdAsync(Guid listingId);
}