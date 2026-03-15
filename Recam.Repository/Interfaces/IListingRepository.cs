using Recam.Models.Entities;

namespace Recam.Repository.Interfaces;

public interface IListingRepository
{
    Task<List<ListingCase>> GetAllAsync();

    Task<ListingCase?> GetByIdAsync(Guid id);

    Task AddAsync(ListingCase listing);

    Task UpdateAsync(ListingCase listing);

    Task DeleteAsync(Guid id);
}