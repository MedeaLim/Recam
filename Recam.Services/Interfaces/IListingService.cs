using Recam.Models.Entities;

namespace Recam.Services.Interfaces;

public interface IListingService
{
    Task<List<ListingCase>> GetAllListingsAsync();

    Task<ListingCase?> GetListingByIdAsync(Guid id);

    Task CreateListingAsync(ListingCase listing);

    Task UpdateListingAsync(ListingCase listing);

    Task DeleteListingAsync(Guid id);
}