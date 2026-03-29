using Recam.Models.Entities;

namespace Recam.Repository.Interfaces;

public interface IListingRepository
{
    Task<object> GetAllAsync(
        string? status,
        string? keyword,
        string? propertyType,
        int page,
        int pageSize);

    Task<ListingCase?> GetByIdAsync(Guid id);

    Task AddAsync(ListingCase listing);

    Task UpdateAsync(ListingCase listing);

    Task DeleteAsync(Guid id);

    Task<List<ListingCase>> GetByAgentIdAsync(string agentId);
}