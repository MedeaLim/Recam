using Recam.Models.Entities;

namespace Recam.Repository.Interfaces;

public interface IMediaRepository
{
    Task AddAsync(MediaAsset media);
    Task<MediaAsset?> GetByIdAsync(Guid id);
    Task<List<MediaAsset>> GetByListingIdAsync(Guid listingId);
    Task<List<MediaAsset>> GetAllAsync();
    Task DeleteAsync(MediaAsset media);
    Task SaveChangesAsync();
}