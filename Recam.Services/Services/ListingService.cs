using Recam.Models.Entities;
using Recam.Repository.Interfaces;
using Recam.Services.Interfaces;

namespace Recam.Services.Services;

public class ListingService : IListingService
{
    private readonly IListingRepository _listingRepository;

    public ListingService(IListingRepository listingRepository)
    {
        _listingRepository = listingRepository;
    }

    public async Task<List<ListingCase>> GetAllListingsAsync()
    {
        return await _listingRepository.GetAllAsync();
    }

    public async Task<ListingCase?> GetListingByIdAsync(Guid id)
    {
        return await _listingRepository.GetByIdAsync(id);
    }

    public async Task CreateListingAsync(ListingCase listing)
    {
        await _listingRepository.AddAsync(listing);
    }

    public async Task UpdateListingAsync(ListingCase listing)
    {
        await _listingRepository.UpdateAsync(listing);
    }

    public async Task DeleteListingAsync(Guid id)
    {
        await _listingRepository.DeleteAsync(id);
    }
}