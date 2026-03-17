using Recam.Models.Entities;

namespace Recam.Repository.Interfaces;

public interface IMediaRepository
{
    Task<List<MediaAsset>> GetAllAsync();

    Task<List<MediaAsset>> GetByListingIdAsync(Guid listingId);

    Task<MediaAsset?> GetByIdAsync(Guid id);

    Task AddAsync(MediaAsset media);

    Task DeleteAsync(MediaAsset media);
}