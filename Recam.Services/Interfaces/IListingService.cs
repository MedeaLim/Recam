using Recam.Models.Entities;

namespace Recam.Services.Interfaces;

public interface IListingService
{
    Task<IEnumerable<ListingCase>> GetAllListingsAsync(
        string? status,
        string? keyword,
        string? propertyType);

    Task<ListingCase?> GetListingByIdAsync(Guid id);

    Task CreateListingAsync(ListingCase listing);

    Task UpdateListingAsync(ListingCase listing);

    Task DeleteListingAsync(Guid id);

    Task UpdateStatusAsync(Guid id, string status);
}