using Recam.Models.Entities;

namespace Recam.Services.Interfaces;

public interface IListingService
{
    Task<object> GetAllListingsAsync(
        string? status,
        string? keyword,
        string? propertyType,
        int page,
        int pageSize);

    Task<ListingCase?> GetListingByIdAsync(Guid id);

    Task CreateListingAsync(ListingCase listing);

    Task UpdateListingAsync(ListingCase listing);

    Task DeleteListingAsync(Guid id);

    Task UpdateStatusAsync(Guid id, string status);
}