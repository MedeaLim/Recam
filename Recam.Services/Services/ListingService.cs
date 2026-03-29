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

    public async Task<object> GetAllListingsAsync(
        string? status,
        string? keyword,
        string? propertyType,
        int page,
        int pageSize)
    {
        return await _listingRepository.GetAllAsync(
            status, keyword, propertyType, page, pageSize);
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

    public async Task UpdateStatusAsync(Guid id, string status)
    {
    var listing = await _listingRepository.GetByIdAsync(id);

    if (listing == null)
        throw new Exception("Listing not found");

    listing.Status = status;

    await _listingRepository.UpdateAsync(listing);
    }
}