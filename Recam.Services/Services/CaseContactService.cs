using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class CaseContactService : ICaseContactService
{
    private readonly ICaseContactRepository _caseContactRepository;
    private readonly IListingRepository _listingRepository;

    public CaseContactService(
        ICaseContactRepository caseContactRepository,
        IListingRepository listingRepository)
    {
        _caseContactRepository = caseContactRepository;
        _listingRepository = listingRepository;
    }

    public async Task AddCaseContactAsync(CaseContact caseContact)
    {
        // 🔥 关键逻辑：检查 listing 是否存在
        var listing = await _listingRepository.GetByIdAsync(caseContact.ListingId);

        if (listing == null)
        {
            throw new Exception("Listing not found");
        }

        await _caseContactRepository.AddAsync(caseContact);
    }

    public async Task<List<CaseContact>> GetByListingIdAsync(Guid listingId)
    {
        return await _caseContactRepository.GetByListingIdAsync(listingId);
    }
}